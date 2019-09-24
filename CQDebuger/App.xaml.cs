using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace CQDebuger
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var pluginDir = Environment.CurrentDirectory + "\\dev";
            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
                MessageBox.Show("请将需要调试的插件放到 " + pluginDir + " 目录下，并保证dll和json文件具有相同的名称。");
            }

            foreach (var filePath in Directory.GetFiles(pluginDir, "*.json"))
                PluginLoader.LoadPlugin(filePath.Remove(filePath.LastIndexOf(".", StringComparison.Ordinal)));
        }
    }
}
