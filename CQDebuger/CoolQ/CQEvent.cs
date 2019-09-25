using System;

namespace CQDebuger.CoolQ
{
    public class CQEvent
    {
        public delegate int AddFriendRequest(int subType, int sendTime, long fromQQ, string msg, string responseFlag);

        public delegate int AddGroupRequest(int subType, int sendTime, long fromGroup, string msg, string responseFlag);

        public delegate IntPtr AppInfoDelegate();

        public delegate int CqExit();

        public delegate int CqStart();

        public delegate int DiscussMsg(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font);

        public delegate int FriendAdd(int subType, int sendTime, long fromQQ);

        public delegate int GroupAdmin(int subType, int sendTime, long fromGroup, long beingOperateQQ);

        public delegate int GroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ,
            long beingOperateQQ);

        public delegate int GroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ,
            long beingOperateQQ);

        public delegate int GroupMsg(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous,
            string msg, int font);

        public delegate int GroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file);

        public delegate int InitializeDelegate(int auth_code);

        public delegate int PluginDisable();

        public delegate int PluginEnable();

        public delegate int PrivateMsg(int subType, int msgId, long fromQQ, string msg, int font);
    }
}