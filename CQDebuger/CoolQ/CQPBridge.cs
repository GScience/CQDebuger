using System;
using System.Security.RightsManagement;

namespace CQDebuger.CoolQ
{
    using CQBool = Int32;

    public static class CQPBridge
    {
        public delegate int AddLog(int authCode, CQLogLevel logLevel, string category, string logMsg);
        public delegate string GetCookies(int authCode);
        public delegate int GetCsrToken(int authCode);
        public delegate int GetLoginQQ(int authCode);
        public delegate string GetLoginNick(int authCode);
        public delegate string GetAppDirectory(int authCode);
        public delegate int SetFatal(int authCode, string errorInfo);
        public delegate string GetRecord(int authCode, string file, string outFormat);

        public delegate int SendGroupMsg(int authCode, long groupId, string msg);
        public delegate int SendPrivateMsg(int authCode, long qq, string msg);
        public delegate int SendDiscussMsg(int authCode, long discussid, string msg);
        public delegate int DeleteMsg(int authCode, long msgId);
        public delegate int SendLike(int authCode, long qqId);
        public delegate int SendLikeV2(int authCode, long qq, int times);
        public delegate int SetGroupKick(int authCode, long groupId, long qqId, CQBool rejectAddRequest);
        public delegate int SetGroupBan(int authCode, long groupId, long qq, long duration);
        public delegate int SetGroupAdmin(int authCode, long groupId, long qqId, CQBool setAdmin);
        public delegate int SetGroupWholeBan(int authCode, long groupId, CQBool enableBan);
        public delegate int SetGroupAnonymousBan(int authCode, long groupId, string anonymous, long duration);
        public delegate int SetGroupAnonymous(int authCode, long groupId, CQBool enableAnonymous);
        public delegate int SetGroupCard(int authCode, long groupId, long qqId, string newCard);
        public delegate int SetGroupLeave(int authCode, long groupId, CQBool isDismiss);
        public delegate int SetGroupSpecialTitle(int authCode, long groupId, long qqId, string newSpecialTitle, long duration);
        public delegate int SetDiscussLeave(int authCode, long discussId);
        public delegate int SetFriendAddRequest(int authCode, string responseFlag, int responseOperation, string remark);
        public delegate int SetGroupAddRequest(int authCode, string responseFlag, int requestType, int responseOperation);
        public delegate int SetGroupAddRequestV2(int authCode, string responseFlag, int requestType, int responseOperation, string reason);
        public delegate string GetGroupMemberInfoV2(int authCode, long groupId, long qqId, CQBool noCache);
        public delegate string GetStrangerInfo(int authCode, long qqId, CQBool noCache);
        public delegate string GetGroupList(int authCode);
        public delegate string GetGroupMemberList(int authCode, long groupId);
        public delegate string GetRecordV2(int authCode, string file, string outFormat);
        public delegate string GetImage(int authCode, string file);
        public delegate int CanSendImage(int authCode);
        public delegate int CanSendRecord(int authCode);
        public delegate int SetRestart(int authCode);

        public static AddLog addLog = (code, level, category, msg) =>
        {
            DebugerApp.AddLog(level, category, msg);

            return 0;
        };

        public static GetCookies getCookies = code =>
        {
            return "不支持功能";
        };

        public static GetCsrToken getCsrToken = code =>
        {
            return 0;
        };

        public static GetLoginQQ getLoginQQ = code =>
        {
            return 0;
        };

        public static GetLoginNick getLoginNick = code =>
        {
            return "Cool Q Debuger";
        };

        public static GetAppDirectory getAppDirectory = code =>
        {
            var plugin = CQPluginLoader.GetPluginByAuthCode(code);
            return plugin?.appDir;
        };

        public static SetFatal setFatal = (code, info) =>
        {
            DebugerApp.AddLog(CQLogLevel.Fatal, "崩溃", info);
            return 0;
        };

        public static GetRecord getRecord = (code, file, format) =>
        {
            return "不支持功能";
        };

        public static SendGroupMsg sendGroupMsg = (code, groupId, msg) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "消息", $"群： {groupId} 接收到群消息消息 {msg}");

            return 0;
        };

        public static SendPrivateMsg sendPrivateMsg = (code, qqId, msg) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "消息", $"用户： {qqId} 接收到私聊消息 {msg}");

            return 0;
        };

        public static SendDiscussMsg sendDiscussMsg = (code, discussId, msg) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "消息", $"发送讨论组消息 {discussId}");
            return 0;
        };

        public static DeleteMsg deleteMsg = (code, msgId) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "撤回", $"Delete Msg {msgId}");
            return 0;
        };

        public static SendLike sendLike = (code, qqId) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "Send Like V2", $"Send Like to {qqId}");
            return 0;
        };

        public static SendLikeV2 sendLikeV2 = (code, qqId, times) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "Send Like", $"Send Like to {qqId} {times} time(s)");
            return 0;
        };

        public static SetGroupKick setGroupKick = (code, groupId, qqId, request) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Kick in {groupId} of {qqId}");
            return 0;
        };

        public static SetGroupBan setGroupBan = (code, groupId, qq, duration) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Ban in {groupId} of {qq} with time {duration}");
            return 0;
        };

        public static SetGroupAdmin setGroupAdmin = (code, groupId, qqId, admin) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Admin in {groupId} of {qqId}");
            return 0;
        };

        public static SetGroupWholeBan setGroupWholeBan = (code, groupId, ban) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group WholeBan of {groupId}");
            return 0;
        };

        public static SetGroupAnonymousBan setGroupAnonymousBan = (code, groupId, anonymous, duration) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Anonymous Ban of {groupId} to {anonymous}");
            return 0;
        };

        public static SetGroupAnonymous setGroupAnonymous = (code, groupId, anonymous) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Anonymous of {groupId} to {anonymous}");
            return 0;
        };

        public static SetGroupCard setGroupCard = (code, groupId, qqId, newCard) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Card for {qqId} in {groupId} to {newCard}");
            return 0;
        };

        public static SetGroupLeave setGroupLeave = (code, groupId, dismiss) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Group Leave of {groupId}");
            return 0;
        };

        public static SetGroupSpecialTitle setGroupSpecialTitle = (code, groupId, qqId, title, duration) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理",
                $"set Group Special Title for {qqId} in group {groupId} to {title} in {duration}");
            return 0;
        };

        public static SetDiscussLeave setDiscussLeave = (code, discussId) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "群管理", $"Set Discuss Leave of {discussId}");
            return 0;
        };

        public static SetFriendAddRequest setFriendAddRequest = (code, responseFlag, operation, remark) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "好友申请", $"Set Friend Add Request of {responseFlag}");
            return 0;
        };

        public static SetGroupAddRequest setGroupAddRequest = (code, responseFlag, type, operation) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "加群申请", $"Set Group Add Request of {responseFlag}");
            return 0;
        };

        public static SetGroupAddRequestV2 setGroupAddRequestV2 = (code, responseFlag, type, operation, reason) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "加群申请", $"Set Group Add Request V2 of {responseFlag}");
            return 0;
        };

        public static GetGroupMemberInfoV2 getGroupMemberInfoV2 = (code, groupId, qqId, cache) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "获取群成员", $"Get Group Member Info V2 of {groupId}");
            return "不支持功能";
        };

        public static GetStrangerInfo getStrangerInfo = (code, qqId, cache) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "获取陌生人", $"Get Stranger Info of {qqId}");
            return "不支持功能";
        };

        public static GetGroupList getGroupList = code =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "获取群列表", "Get Group List");
            return "不支持功能";
        };

        public static GetGroupMemberList getGroupMemberList = (code, id) =>
        {
            DebugerApp.AddLog(CQLogLevel.InfoSend, "获取成员信息", $"Get Group Member List of{id}");
            return "不支持功能";
        };

        public static GetRecordV2 getRecordV2 = (code, file, format) =>
        {
            return "不支持功能";
        };

        public static GetImage getImage = (code, file) =>
        {
            return "不支持功能";
        };

        public static CanSendImage canSendImage = code =>
        {
            return 2;
        };

        public static CanSendRecord canSendRecord = code =>
        {
            return 2;
        };

        public static SetRestart setRestart = code =>
        {
            return 0;
        };
    }
}