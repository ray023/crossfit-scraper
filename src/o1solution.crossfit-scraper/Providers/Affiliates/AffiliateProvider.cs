using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using o1solution.crossfitscraper.AsyncLoaders;
using o1solution.crossfitscraper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.Affiliates
{
    internal class AffiliateProvider : IAffiliateProvider
    {
        public async Task<List<Affiliate>> GetCurrentAffiliateListAsync()
        {
            var affiliateList = this.GetAffiliateListFromCrossFitDotCom();
            var affiliateDetailsLoader = new AffiliateDetailsLoader(affiliateList);
            await affiliateDetailsLoader.PopulateAffiliateDetailsAsync();
            return affiliateList.ToList();
        }
        public List<Affiliate> GetCurrentAffiliateList()
        {
            return this.GetCurrentAffiliateListAsync().Result;
        }

        private Affiliate[] GetAffiliateListFromCrossFitDotCom()
        {
            return JsonConvert
                    .DeserializeObject<JArray[]>(
                        new HttpClient()
                            .GetStringAsync(ConfigurationManager.AppSettings["GetAllAffiliatesUrl"]).Result)
                            .Select(x => new Affiliate
                            {
                                Latitude = (float)x[0],
                                Longitude = (float)x[1],
                                Name = (string)x[2],
                                AffiliteId = (int)x[3],
                                SecretField = (int)x[4]
                            })
                            .ToArray();
        }
    }
}