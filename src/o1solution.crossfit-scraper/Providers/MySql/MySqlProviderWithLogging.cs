using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o1solution.crossfitscraper.Models;
using System.Diagnostics;

namespace o1solution.crossfitscraper.Providers.MySql
{
    public class MySqlProviderWithLogging : IMySqlProvider
    {
        private readonly MySqlProvider _provider;

        public MySqlProviderWithLogging()
        {
            _provider = new MySqlProvider();
        }
        public string GetAffiliatePopulateSql(List<Affiliate> affiliateList)
        {
            WindowsEventLogger.WriteEventLogEntry("GetAffiliatePopulateSql", EventLogEntryType.Information);
            return _provider
                    .GetAffiliatePopulateSql(affiliateList);
        }

        public string GetEventPopulateSql(List<Event> events)
        {
            WindowsEventLogger.WriteEventLogEntry("GetEventPopulateSql", EventLogEntryType.Information);
            return _provider
                    .GetEventPopulateSql(events);
        }
    }
}
