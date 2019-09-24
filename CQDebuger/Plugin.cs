using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CQDebuger
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

    public struct PluginInfo
    {
        public int rev;
        public int apiver;
        public string name;
        public string version;
        public int versionId;
        public string author;
        public string description;
        public List<PluginEvent> eventList;
    }

    public class Plugin
    {
        public int apiVersion;
        public string appId;

        public IntPtr dllModule;

        public delegate IntPtr AppInfoDelegate();
        public delegate int InitializeDelegate();

        public delegate int PluginEnable();
        public delegate int PluginDisable();
        public delegate int CqStart();
        public delegate int CqExit();

        public delegate int PrivateMsg(int subType, int msgId, long fromQQ, string msg, int font);
        public delegate int GroupMsg(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font);
        public delegate int DiscussMsg(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font);
        public delegate int GroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file);
        public delegate int GroupAdmin(int subType, int sendTime, long fromGroup, long beingOperateQQ);
        public delegate int GroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ);
        public delegate int GroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ);
        public delegate int FriendAdd(int subType, int sendTime, long fromQQ);
        public delegate int AddFriendRequest(int subType, int sendTime, long fromQQ, string msg, string responseFlag);
        public delegate int AddGroupRequest(int subType, int sendTime, long fromGroup, string msg, string responseFlag);

        public AppInfoDelegate appInfo;
        public InitializeDelegate initialize;

        public PluginEnable pluginEnable;
        public PluginDisable pluginDisable;
        public CqStart cqStart;
        public CqExit cqExit;

        public PrivateMsg privateMsg;
        public GroupMsg groupMsg;
        public DiscussMsg discussMsg;
        public GroupUpload groupUpload;
        public GroupAdmin groupAdmin;
        public GroupMemberDecrease groupMemberDecrease;
        public GroupMemberIncrease groupMemberIncrease;
        public FriendAdd friendAdd;
        public AddFriendRequest addFriendRequest;
        public AddGroupRequest addGroupRequest;
    }
}
