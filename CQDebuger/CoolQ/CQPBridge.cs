namespace CQDebuger.CoolQ
{
    public static class CQPBridge
    {
        public delegate int AddLog(int auth_code, int log_level, string category, string log_msg);

        public delegate int SendGroupMsg(int auth_code, long group_id, string msg);

        public delegate int SendPrivateMsg(int auth_code, long qq, string msg);

        public const string BridgeDebugCategory = "酷Q接收";

        public static SendPrivateMsg sendPrivateMsg = (code, qq, msg) =>
        {
            App.AddLog(BridgeDebugCategory, $"用户： {qq} 接收到私聊消息 {msg}");

            return 0;
        };

        public static SendGroupMsg sendGroupMsg = (code, group_id, msg) =>
        {
            App.AddLog(BridgeDebugCategory, $"群： {group_id} 接收到群消息消息 {msg}");

            return 0;
        };

        public static AddLog addLog = (code, level, category, msg) =>
        {
            App.AddLog(category, msg);

            return 0;
        };
    }
}