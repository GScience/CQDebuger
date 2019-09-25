using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using CQDebuger.CoolQ;

namespace CQDebuger.Window
{
    /// <summary>
    ///     DebugWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DebugWindow : System.Windows.Window
    {
        public static DebugWindow Instance;

        public DebugWindow()
        {
            InitializeComponent();

            var pluginNameList = new List<PluginInfo>();

            foreach (var plugin in CQPluginLoader.plugins)
                pluginNameList.Add(plugin.info);

            PluginList.ItemsSource = pluginNameList;
        }

        public PluginInfo GetSelectedPlugin => (PluginInfo) PluginList.SelectedItem;

        public void AddLog(DebugLog debugLog)
        {
            LogList.Items.Add(debugLog);
            LogList.ScrollIntoView(LogList.Items[LogList.Items.Count - 1]);
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Instance = null;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Instance = this;
        }

        private void GroupMsgSend_Click(object sender, RoutedEventArgs e)
        {
            App.LogWhenThrow(() => App.GroupMsgEvent(
                int.Parse(GroupMsgSubType.TextBoxText),
                int.Parse(GroupMsgMsgId.TextBoxText),
                long.Parse(GroupMsgFromGroup.TextBoxText),
                long.Parse(GroupMsgFromQq.TextBoxText),
                GroupMsgFromAnonymous.TextBoxText,
                GroupMsgMsg.TextBoxText,
                int.Parse(GroupMsgFont.TextBoxText)));
        }

        private void PrivateMsgSend_Click(object sender, RoutedEventArgs e)
        {
            App.LogWhenThrow(() => App.PrivateMsgEvent(
                int.Parse(PrivateMsgSubType.TextBoxText),
                int.Parse(PrivateMsgMsgId.TextBoxText),
                long.Parse(PrivateMsgFromQq.TextBoxText),
                PrivateMsgMsg.TextBoxText,
                int.Parse(PrivateMsgFont.TextBoxText)));
        }
    }
}