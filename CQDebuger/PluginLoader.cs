using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CQDebuger
{
    public class PluginLoader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string path);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpLibFileNmae);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        public static PluginLoader Instance;

        static PluginLoader()
        {
            Instance = new PluginLoader();
        }

        public static void LoadPlugin(string pluginPath)
        {
            Instance.LoadPluginInner(pluginPath);
        }
        private object GetProcAs(IntPtr dllModule, string apiName, Type type)
        {
            var address = GetProcAddress(dllModule, apiName);
            if (address.ToInt32() == 0)
                return null;
            return Marshal.GetDelegateForFunctionPointer(address, type);
        }
        private T GetProcAs<T>(IntPtr dllModule, string apiName) where T : class
        {
            return (T) GetProcAs(dllModule, apiName, typeof(T));
        }

        private string GetString(IntPtr addr)
        {
            return Marshal.PtrToStringAnsi(addr);
        }

        private void AddEventToPlugin(Plugin plugin, PluginEvent pluginEvent)
        {
            var eventTypeName = pluginEvent.type.ToString();
            var fieldNameCharArray = eventTypeName.ToCharArray();
            fieldNameCharArray[0] = char.ToLower(eventTypeName[0]);
            var fieldName = new string(fieldNameCharArray);

            var fieldInfo = plugin.GetType().GetField(fieldName);

            if (fieldInfo == null)
                throw new MissingFieldException("未找到事件 " + fieldName);

            fieldInfo.SetValue(
                plugin, 
                GetProcAs(plugin.dllModule, pluginEvent.function, fieldInfo.FieldType));
        }

        private Plugin LoadPluginInner(string pluginPath)
        {
            var dllPath = pluginPath + ".dll";
            var jsonPath = pluginPath + ".json";

            if (!File.Exists(dllPath))
                throw new ArgumentException("未找到文件 " + dllPath);
            if (!File.Exists(jsonPath))
                throw new ArgumentException("未找到文件 " + jsonPath);

            var plugin = new Plugin();

            //加载Dll
            plugin.dllModule = LoadLibrary(dllPath);
            plugin.appInfo = GetProcAs<Plugin.AppInfoDelegate>(plugin.dllModule, "AppInfo");
            plugin.initialize = GetProcAs<Plugin.InitializeDelegate>(plugin.dllModule, "Initialize");

            //获取插件基本信息
            var appInfo = GetString(plugin.appInfo());
            var infoArray = appInfo.Split(',');

            if (infoArray.Length != 2)
                throw new ArgumentException("获取到非法appInfo: " + appInfo + "不符合 \"apiVersion.appId\" 要求");

            if (!int.TryParse(infoArray[0], out plugin.apiVersion))
                throw new ArgumentException("获取到非法appInfo: " + infoArray[0] + "不是一个有效的int整数");

            plugin.appId = infoArray[1];

            //解析Json获得插件详细信息
            var jsonFile = File.OpenRead(jsonPath);
            var jsonFileReader = new StreamReader(jsonFile);
            var jsonStr = jsonFileReader.ReadToEnd();
            jsonStr = jsonStr.Replace("\"event\"", "\"eventList\"");
            var pluginInfo = JsonConvert.DeserializeObject<PluginInfo>(jsonStr);

            //判断Api版本
            if (pluginInfo.apiver != plugin.apiVersion)
                throw new ArgumentException("Json中定义的ApiVersion为 " + plugin.apiVersion +
                                            " 但是AppInfo当中的ApiVersion为" + plugin.apiVersion);

            //获取事件信息
            foreach (var pluginEvent in pluginInfo.eventList)
                AddEventToPlugin(plugin, pluginEvent);

            //插件加载完成
            return plugin;
        }
    }
}
