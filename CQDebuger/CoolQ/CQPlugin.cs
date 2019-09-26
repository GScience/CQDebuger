using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQDebuger.CoolQ
{
    public enum PluginEventType
    {
        PrivateMsg = 21,
        GroupMsg = 2,
        DiscussMsg = 4,
        GroupUpload = 11,

        GroupAdmin = 101,
        GroupMemberDecrease = 102,
        GroupMemberIncrease = 103,

        FriendAdd = 201,

        AddFriendRequest = 301,
        AddGroupRequest = 302,

        CqStart = 1001,
        CqExit = 1002,
        PluginEnable = 1003,
        PluginDisable = 1004
    }

    public struct PluginEvent
    {
        public int id;
        public PluginEventType type;
        public string name;
        public int priority;
        public string function;
    }

    public class PluginInfo
    {
        public int apiver;
        public string author;
        public string description;
        public List<PluginEvent> eventList;
        public List<int> auth;
        public string name;
        public int rev;
        public string version;
        public int versionId;

        public string Name => name;
        public string Version => version;
        public string Author => author;
        public string Description => description;
    }

    public class CQPlugin
    {
        public CQEvent.AddFriendRequest addFriendRequest;
        public CQEvent.AddGroupRequest addGroupRequest;

        public int apiVersion;
        public string appId;

        public CQEvent.AppInfoDelegate appInfo;
        public int authCode;
        public CQEvent.CqExit cqExit;
        public CQEvent.CqStart cqStart;
        public CQEvent.DiscussMsg discussMsg;

        public IntPtr dllModule;
        public CQEvent.FriendAdd friendAdd;
        public CQEvent.GroupAdmin groupAdmin;
        public CQEvent.GroupMemberDecrease groupMemberDecrease;
        public CQEvent.GroupMemberIncrease groupMemberIncrease;
        public CQEvent.GroupMsg groupMsg;
        public CQEvent.GroupUpload groupUpload;
        public PluginInfo info;
        public CQEvent.InitializeDelegate initialize;
        public CQEvent.PluginDisable pluginDisable;

        public CQEvent.PluginEnable pluginEnable;

        public CQEvent.PrivateMsg privateMsg;

        public CQPlugin()
        {
            authCode = new Random().Next();
        }

        public static FieldInfo GetEvent(PluginEventType eventType)
        {
            var eventTypeName = eventType.ToString();
            var fieldName = eventTypeName.First().ToString().ToLower() + eventTypeName.Substring(1);
            return typeof(CQPlugin).GetField(fieldName);
        }
    }
}