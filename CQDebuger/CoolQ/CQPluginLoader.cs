using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace CQDebuger.CoolQ
{
    public class CQPluginLoader
    {
        public static List<CQPlugin> plugins = new List<CQPlugin>();

        public static CQPluginLoader Instance;

        static CQPluginLoader()
        {
            Instance = new CQPluginLoader();
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string path);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpLibFileNmae);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        public static CQPlugin LoadPlugin(string pluginPath)
        {
            var plugin = Instance.LoadPluginInner(pluginPath);
            plugins.Add(plugin);
            return plugin;
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

        private void AddEventToPlugin(CQPlugin plugin, PluginEvent pluginEvent)
        {
            var eventType = pluginEvent.type;
            var fieldInfo = CQPlugin.GetEvent(eventType);

            if (fieldInfo == null)
                throw new MissingFieldException("未找到事件 " + eventType);

            fieldInfo.SetValue(
                plugin,
                GetProcAs(plugin.dllModule, pluginEvent.function, fieldInfo.FieldType));
        }

        private CQPlugin LoadPluginInner(string pluginPath)
        {
            var dllPath = pluginPath + "app.dll";
            var jsonPath = pluginPath + "app.json";

            if (!File.Exists(dllPath))
                throw new ArgumentException("未找到文件 " + dllPath);
            if (!File.Exists(jsonPath))
                throw new ArgumentException("未找到文件 " + jsonPath);

            var plugin = new CQPlugin
            {
                dllModule = LoadLibrary(dllPath)
            };

            //加载Dll
            plugin.appInfo = GetProcAs<CQEvent.AppInfoDelegate>(plugin.dllModule, "AppInfo");
            plugin.initialize = GetProcAs<CQEvent.InitializeDelegate>(plugin.dllModule, "Initialize");

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
            plugin.info = JsonConvert.DeserializeObject<PluginInfo>(jsonStr);

            //判断Api版本
            if (plugin.info.apiver != plugin.apiVersion)
                throw new ArgumentException("Json中定义的ApiVersion为 " + plugin.apiVersion +
                                            " 但是AppInfo当中的ApiVersion为" + plugin.apiVersion);

            //获取事件信息
            foreach (var pluginEvent in plugin.info.eventList)
                AddEventToPlugin(plugin, pluginEvent);

            //插件加载完成
            return plugin;
        }
    }
}