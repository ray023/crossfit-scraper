using o1solution.crossfitscraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.MySql
{
    public interface IMySqlProvider
    {
        string GetEventPopulateSql(List<Event> eventList);
        string GetAffiliatePopulateSql(List<Affiliate> affiliateList);
    }
}
