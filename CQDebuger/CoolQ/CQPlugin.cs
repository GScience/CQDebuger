using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;

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
        PluginDisable = 1004,
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
        public int rev;
        public int apiver;
        public string name;
        public string version;
        public int versionId;
        public string author;
        public string description;
        public List<PluginEvent> eventList;

        public string Name => name;
        public string Version => version;
        public string Author => author;
        public string Description => description;
    }

    public class CQPlugin
    {
        public int authCode;
        public PluginInfo info;

        public int apiVersion;
        public string appId;

        public IntPtr dllModule;

        public CQEvent.AppInfoDelegate appInfo;
        public CQEvent.InitializeDelegate initialize;

        public CQEvent.PluginEnable pluginEnable;
        public CQEvent.PluginDisable pluginDisable;
        public CQEvent.CqStart cqStart;
        public CQEvent.CqExit cqExit;

        public CQEvent.PrivateMsg privateMsg;
        public CQEvent.GroupMsg groupMsg;
        public CQEvent.DiscussMsg discussMsg;
        public CQEvent.GroupUpload groupUpload;
        public CQEvent.GroupAdmin groupAdmin;
        public CQEvent.GroupMemberDecrease groupMemberDecrease;
        public CQEvent.GroupMemberIncrease groupMemberIncrease;
        public CQEvent.FriendAdd friendAdd;
        public CQEvent.AddFriendRequest addFriendRequest;
        public CQEvent.AddGroupRequest addGroupRequest;

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
