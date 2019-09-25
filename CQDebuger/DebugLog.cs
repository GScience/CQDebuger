using System;

namespace CQDebuger
{
    public class DebugLog
    {
        public DebugLog(string category, string msg)
        {
            LogTime = DateTime.Now.ToLongTimeString();
            Category = category;
            Msg = msg;
        }

        public string LogTime { get; }

        public string Category { get; }

        public string Msg { get; }

        public override string ToString()
        {
            return $"::[{LogTime}][{Category}]{Msg}";
        }
    }
}