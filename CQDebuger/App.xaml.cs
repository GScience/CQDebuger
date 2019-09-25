using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CQDebuger.CoolQ;
using CQDebuger.Window;

namespace CQDebuger
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public DebugWindow debugWindow;

        public event CQEvent.AppInfoDelegate AppInfo;
        public event CQEvent.InitializeDelegate Initialize;

        public event CQEvent.PluginEnable PluginEnable;
        public event CQEvent.PluginDisable PluginDisable;
        public event CQEvent.CqStart CQStart;
        public event CQEvent.CqExit CQExit;

        public event CQEvent.PrivateMsg PrivateMsg;
        public event CQEvent.GroupMsg GroupMsg;
        public event CQEvent.DiscussMsg DiscussMsg;
        public event CQEvent.GroupUpload GroupUpload;
        public event CQEvent.GroupAdmin GroupAdmin;
        public event CQEvent.GroupMemberDecrease GroupMemberDecrease;
        public event CQEvent.GroupMemberIncrease GroupMemberIncrease;
        public event CQEvent.FriendAdd FriendAdd;
        public event CQEvent.AddFriendRequest AddFriendRequest;
        public event CQEvent.AddGroupRequest AddGroupRequest;

        private void LoadPlugins()
        {
            var pluginDir = Environment.CurrentDirectory + "\\dev";
            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
                MessageBox.Show("请将需要调试的插件放到 " + pluginDir + " 目录下，并保证dll和json文件具有相同的名称。");
            }
            
            foreach (var filePath in Directory.GetFiles(pluginDir, "*.json"))
            {
                var pluginPath = filePath.Remove(filePath.LastIndexOf(".", StringComparison.Ordinal));
                var plugin = CQPluginLoader.LoadPlugin(pluginPath);

                AppInfo += plugin.appInfo;
                Initialize += plugin.initialize;
                PluginEnable += plugin.pluginEnable;
                PluginDisable += plugin.pluginDisable;
                CQStart += plugin.cqStart;
                CQExit += plugin.cqExit;
                PrivateMsg += plugin.privateMsg;
                GroupMsg += plugin.groupMsg;
                DiscussMsg += plugin.discussMsg;
                GroupUpload += plugin.groupUpload;
                GroupAdmin += plugin.groupAdmin;
                GroupMemberDecrease += plugin.groupMemberDecrease;
                GroupMemberIncrease += plugin.groupMemberIncrease;
                FriendAdd += plugin.friendAdd;
                AddFriendRequest += plugin.addFriendRequest;
                AddGroupRequest += plugin.addGroupRequest;

                Initialize?.Invoke(plugin.authCode);
            }
        }

        private void LoadCQP()
        {
            CQPluginLoader.LoadLibrary("CQP.dll");
        }

        public App()
        {
            LoadCQP();
            LoadPlugins();

            CQStart?.Invoke();
            PluginEnable?.Invoke();
        }

        public static void AddLog(string category, string msg)
        {
            DebugWindow.AddLog(category, msg);
        }

        public static void GroupMsgEvent(
            int subType,
            int msgId,
            long fromGroup,
            long fromQQ,
            string fromAnonymous,
            string msg,
            int font)
        {
            ((App)Current).GroupMsg(subType, msgId, fromGroup, fromQQ, fromAnonymous, msg, font);
        }
        public static void PrivateMsgEvent(
            int subType,
            int msgId,
            long fromQQ,
            string msg,
            int font)
        {
            ((App)Current).PrivateMsg(subType, msgId, fromQQ, msg, font);
        }
    }
}
