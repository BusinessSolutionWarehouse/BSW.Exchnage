﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSW_ExchangeData;
using System.IO;
using System.Windows.Forms;

namespace BSW_ExchangeShared
{

   
    /// <summary>
    /// Log all the events for the service
    /// </summary>
    public static class EventLog
    {
        private const string AppName = "BSWExchangeService";
        private static string LogFolder = Application.StartupPath + @"\LogFiles";
        private static bool LogErrorsOnly = false;

        /// <summary>
        /// Log a event to the database log table/or local log file
        /// </summary>
        /// <param name="processName">Process that raised the event</param>
        /// <param name="eventDescription">Description of the event</param>
        /// <param name="eventType">Type of event</param>
        public static void LogEvent(string processName, string eventDescription, EventLogType eventType)
        {
            try
            {
                string msg = string.Empty;
                //we firt try to log the event to the database
                using (EventLogModel model = new EventLogModel())
                {
                    model.EventProcess = processName;
                    model.EventDescription = eventDescription;
                    model.EventTypeID = (Int16)eventType;
                    try
                    {
                        using (EventLogController controller = new EventLogController())
                        {
                            if(!controller.Insert(model,ref msg))
                                //log issue to local log file
                                LogEventLocally(msg, processName, eventDescription, eventType);
                        }
                    }
                    catch (Exception exp)
                    {
                        //log the error to the local log file
                        LogEventLocally(exp.Message,processName,eventDescription,eventType);
                    }
                }

            }
            catch(Exception exp)
            {
                LogEventLocally(exp.Message, processName, eventDescription, eventType);
            }
        }

        /// <summary>
        /// Log any event and errors to a local log file
        /// </summary>
        /// <param name="error">Error raised by the database log event</param>
        /// <param name="processName">Processe that raised the event</param>
        /// <param name="eventDescription">Description of the event</param>
        /// <param name="eventType">Event Type</param>
        private static void LogEventLocally(string error, string processName, string eventDescription, EventLogType eventType)
        {
            try
            {
                string fileName = CurrentLogFile;
                if (fileName.Length > 0)
                {
                    //we may very well have more then on process writing to this file at the same time
                    using (FileStream fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                                             
                        using (StreamWriter writer = new StreamWriter(fStream))
                        {
                            //we firts need to set the error raised by the database logging event
                            string line = string.Format("[{0:T}] - ProcessNo : {1} {2}", DateTime.Now, "Database Event Logging", "[ERROR] - " + error);
                            writer.WriteLine(line);

                            line = string.Empty;

                            switch (eventType)
                            {
                                case EventLogType.Error:
                                    line = string.Format("[{0:T}] - ProcessNo : {1} {2}", DateTime.Now, processName, "[ERROR] - " + eventDescription);
                                   break;
                                case  EventLogType.Information:
                                    if (!LogErrorsOnly)
                                        line = string.Format("[{0:T}] - ProcessNo : {1} {2}", DateTime.Now, processName, "[INFORMATION] - " + eventDescription);

                                    break;
                                case EventLogType.Warning:
                                    if (!LogErrorsOnly)
                                        line = string.Format("[{0:T}] - ProcessNo : {1} {2}", DateTime.Now, processName, "[WARNING] - " + eventDescription);
                                    break;
                            }

                            if (line.Length > 0)
                                writer.WriteLine(line);
                        }
                        fStream.Flush();
                        fStream.Close();
                    }
                }
            }
            catch
            {
                //do nothign for now - only updatting the log file
            }
        }

        /// <summary>
        /// Validate the current log file folder and path
        /// </summary>
        private static bool ValidateLogFolder()
        {
            bool result = true;

            try
            {
                //if the log fle foder is not set - we default to the application path
                if (LogFolder.Length == 0)
                    LogFolder = Application.StartupPath + @"\LogFiles";

                if (!Directory.Exists(LogFolder))
                    Directory.CreateDirectory(LogFolder);
            }
            catch (Exception exp)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Get the current active log file name and full path
        /// </summary>
        public static string CurrentLogFile
        {
            get
            {
                string logfile = "";
                if (ValidateLogFolder())
                {
                    logfile = LogFolder + @"\" + string.Format("{0}_{1:yyyy.MM.dd}.log", AppName, DateTime.Now);
                }

                return logfile;
            }
        }

        /// <summary>
        /// Log Events that happend on a profile
        /// </summary>
        /// <param name="profileID">Active Profile ID</param>
        /// <param name="eventDescription">Description of the event</param>
        /// <param name="eventType">Type of event</param>
        public static void LogProfileEvent(byte profileID,string eventDescription,EventLogType eventType)
        {
            try
            {
                string msg = string.Empty;
                //we firt try to log the event to the database
                using (ProfileHistoryModel model = new ProfileHistoryModel())
                {
                    model.ProfileID = profileID;
                    model.Eventdescription = eventDescription;
                    model.EventTypeID = (byte)eventType;
                    try
                    {
                        using (ProfileHistoryController controller = new ProfileHistoryController())
                        {
                            if (!controller.Insert(model, ref msg))
                                //log issue to local log file
                                LogEventLocally(msg, "BSWExchange-LogProfileHistory", eventDescription, eventType);
                        }
                    }
                    catch (Exception exp)
                    {
                        //log the error to the local log file
                        LogEventLocally(exp.Message, "BSWExchange-LogProfileHistory", eventDescription, eventType);
                    }
                }

            }
            catch (Exception exp)
            {
                LogEventLocally(exp.Message,"BSWExchange - LogProfileHistory", eventDescription, eventType);
            }
        }
    }
}
