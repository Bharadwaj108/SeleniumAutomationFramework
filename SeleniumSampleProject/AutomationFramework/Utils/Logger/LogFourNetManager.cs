using System;
using System.IO;
using AutomationFramework.Config;
using log4net;
using log4net.Appender;
using log4net.Config;

namespace AutomationFramework.Utils.Logger
{
    public class LogFourNetManager : LogBase
    {
        public static void ConfigureLogFile(string logFileLocation)
        {           
            XmlConfigurator.Configure();
            log4net.Repository.Hierarchy.Hierarchy h =
            (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a is FileAppender)
                {
                    FileAppender fa = (FileAppender)a;
                    fa.File = logFileLocation;
                    fa.ActivateOptions();
                    break;
                }
            }
        }

        public override void Log(string message)
        {
            LogHelper.log.Info(message);
        }

        public override void Log(string message, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    LogHelper.log.Error(message);
                    break;
                case LogType.Info:
                    LogHelper.log.Info(message);
                    break;
                case LogType.Fatal:
                    LogHelper.log.Fatal(message);
                    break;
                case LogType.Warning:
                    LogHelper.log.Warn(message);
                    break;
                default:
                    LogHelper.log.Info(message);
                    break;
            }
        }
       
       
    }
   
}
