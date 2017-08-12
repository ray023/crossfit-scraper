using o1solution.crossfitscraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.Affiliates
{
    public interface IAffiliateProvider
    {
        List<Affiliate> GetCurrentAffiliateList();
    }
}
