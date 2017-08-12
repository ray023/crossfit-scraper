using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace o1solution.crossfitscraper
{
    public static class WindowsEventLogger
    {
        public static void WriteEventLogEntry(string message, EventLogEntryType eventLogEntryType)
        {
            EventLog eventLog = new EventLog();

            if (!EventLog.SourceExists(ConfigurationManager.AppSettings["WindowsEventSourceName"]))
                EventLog.CreateEventSource(ConfigurationManager.AppSettings["WindowsEventSourceName"], "Application");

            eventLog.Source = ConfigurationManager.AppSettings["WindowsEventSourceName"];


            eventLog.WriteEntry(message, 
                                eventLogEntryType,
                                int.Parse(ConfigurationManager.AppSettings["WindowsEventId"]));

            eventLog.Close();
        }
    }
}
