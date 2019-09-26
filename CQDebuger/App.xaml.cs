using System;
using System.IO;
using System.Windows;
using CQDebuger.CoolQ;
using CQDebuger.Window;

namespace CQDebuger
{
    /// <summary>
    ///     App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public const string DebugerLogCategory = "酷Q调试器";

        public App()
        {
            LoadCQP();
            LogWhenThrow(LoadPlugins);

            LogWhenThrow(() => CQStart?.Invoke());
            LogWhenThrow(() => PluginEnable?.Invoke());
        }

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
                AddLog(DebugerLogCategory, "请将需要调试的插件放到 " + pluginDir + " 目录下，并保证dll和json文件具有相同的名称。");
            }

            foreach (var pluginPath in Directory.GetDirectories(pluginDir))
            {
                var plugin = CQPluginLoader.LoadPlugin(pluginPath + "\\");

                var dirName = pluginPath.Substring(pluginPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);

                if (plugin.appId != dirName)
                {
                    AddLog(DebugerLogCategory, "插件ID \"" + plugin.appId + "\" 与其所在文件夹名不相符， 文件夹名为 \"" + dirName + "\"");
                    continue;
                }
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
            if (CQPluginLoader.LoadLibrary("CQP.dll").ToInt32() == 0)
                MessageBox.Show("未能找到 CQP.dll ，调试器运行将出现未预期的错误。");
        }

        public static void LogWhenThrow(Action action, bool throwWhenError = false)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                AddLog(DebugerLogCategory, "运行时出现错误，可能是用户参数问题，也可能是程序内部或插件问题：\n" + e);

                if (throwWhenError)
                    throw;
            }
        }

        public static void AddLog(string category, string msg)
        {
            var debugLog = new DebugLog(category, msg);

            if (DebugWindow.Instance != null)
                DebugWindow.Instance.AddLog(debugLog);

            Console.WriteLine(debugLog.ToString());
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
            LogWhenThrow(() => ((App) Current).GroupMsg(subType, msgId, fromGroup, fromQQ, fromAnonymous, msg, font));
        }

        public static void PrivateMsgEvent(
            int subType,
            int msgId,
            long fromQQ,
            string msg,
            int font)
        {
            LogWhenThrow(() => ((App) Current).PrivateMsg(subType, msgId, fromQQ, msg, font));
        }
    }
}