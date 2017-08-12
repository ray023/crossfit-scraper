using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using o1solution.crossfitscraper;
using o1solution.crossfitscraper.Models;
using System.Diagnostics;

namespace o1solution.crossfitscraper.Providers.Events
{
    public class EventProviderWithLogging : IEventProvider
    {
        private readonly EventProvider _provider;
        public EventProviderWithLogging()
        {
            _provider = new EventProvider();
        }
        public List<Event> GetCurrentEventList()
        {
            WindowsEventLogger.WriteEventLogEntry("Getting Events...", EventLogEntryType.Information);

            return _provider
                            .GetCurrentEventList();

        }
    }
}
