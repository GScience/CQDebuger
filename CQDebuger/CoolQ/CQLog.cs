using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CQDebuger.CoolQ
{
    public enum CQLogLevel
    {
        Debug = 0, //调试 灰色
        Info = 10, //信息 黑色
        InfoSuccess = 11, //信息(成功) 紫色
        InfoRecv = 12, //信息(接收) 蓝色
        InfoSend = 13, //信息(发送) 绿色
        Warning = 20, //警告 橙色
        Error = 30, //错误 红色
        Fatal = 40 //致命错误 深红
    }

    public class CQLog
    {
        public CQLog(CQLogLevel logLevel, string category, string msg)
        {
            LogLevel = logLevel;
            LogTime = DateTime.Now.ToLongTimeString();
            Category = category;
            Msg = msg;
        }

        public CQLogLevel LogLevel { get; }

        public Color LogColor
        {
            get
            {
                switch (LogLevel)
                {
                    case CQLogLevel.Debug:
                        return Colors.Gray;
                    case CQLogLevel.Info:
                        return Colors.Black;
                    case CQLogLevel.InfoSuccess:
                        return Colors.Purple;
                    case CQLogLevel.InfoRecv:
                        return Colors.Blue;
                    case CQLogLevel.InfoSend:
                        return Colors.Green;
                    case CQLogLevel.Warning:
                        return Colors.Orange;
                    case CQLogLevel.Error:
                        return Colors.Red;
                    case CQLogLevel.Fatal:
                        return Colors.DarkRed;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public SolidColorBrush LogBrush => new SolidColorBrush(LogColor);

        public string LogTime { get; }

        public string Category { get; }

        public string Msg { get; }

        public override string ToString()
        {
            return $"::[{LogTime}][{Category}]{Msg}";
        }
    }
}
