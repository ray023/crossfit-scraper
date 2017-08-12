using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o1solution.crossfitscraper.Models;
using System.Diagnostics;

namespace o1solution.crossfitscraper.Providers.Affiliates
{
    public class AffiliateProviderWithLogging : IAffiliateProvider
    {
        AffiliateProvider _provider;
        public AffiliateProviderWithLogging()
        {
            _provider = new AffiliateProvider();
        }

        public List<Affiliate> GetCurrentAffiliateList()
        {
            WindowsEventLogger.WriteEventLogEntry("GetCurrentAffiliateList", EventLogEntryType.Information);
            return _provider.GetCurrentAffiliateList();
        }
    }
}
