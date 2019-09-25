using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using CQDebuger.CoolQ;
using Microsoft.Win32;

namespace CQDebuger.Window
{
    /// <summary>
    /// DebugWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DebugWindow : System.Windows.Window
    {
        public const string DebugerLogCategory = "酷Q调试器";
        private static DebugWindow _instance;

        public PluginInfo GetSelectedPlugin => (PluginInfo) PluginList.SelectedItem;

        public DebugWindow()
        {
            InitializeComponent();

            var pluginNameList = new List<PluginInfo>();

            foreach (var plugin in CQPluginLoader.plugins)
                pluginNameList.Add(plugin.info);

            PluginList.ItemsSource = pluginNameList;
        }

        public void LogWhenThrow(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                AddLog(DebugerLogCategory, "运行时出现错误，可能是用户参数问题，也可能是程序内部或插件问题：" + e);
                throw;
            }
        }
        public static void AddLog(string category, string msg)
        {
            var debugLog = new DebugLog(category, msg);

            Console.WriteLine(debugLog.ToString());

            if (_instance == null)
                return;

            var logListBox = _instance.LogList;

            logListBox.Items.Add(debugLog);
            logListBox.ScrollIntoView(logListBox.Items[logListBox.Items.Count - 1]);
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instance = null;
        }

        private void OnWindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _instance = this;
        }

        private void GroupMsgSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogWhenThrow(() => App.GroupMsgEvent(
                int.Parse(GroupMsgSubType.TextBoxText),
                int.Parse(GroupMsgMsgId.TextBoxText),
                long.Parse(GroupMsgFromGroup.TextBoxText),
                long.Parse(GroupMsgFromQq.TextBoxText),
                GroupMsgFromAnonymous.TextBoxText,
                GroupMsgMsg.TextBoxText,
                int.Parse(GroupMsgFont.TextBoxText)));
        }

        private void PrivateMsgSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogWhenThrow(() => App.PrivateMsgEvent(
                int.Parse(PrivateMsgSubType.TextBoxText),
                int.Parse(PrivateMsgMsgId.TextBoxText),
                long.Parse(PrivateMsgFromQq.TextBoxText),
                PrivateMsgMsg.TextBoxText,
                int.Parse(PrivateMsgFont.TextBoxText)));
        }
    }
}
