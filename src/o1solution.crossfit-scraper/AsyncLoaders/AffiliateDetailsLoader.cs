using Newtonsoft.Json;
using o1solution.crossfitscraper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.AsyncLoaders
{
    internal class AffiliateDetailsLoader
    {
        private Affiliate[] _affiliateArray;

        public AffiliateDetailsLoader(Affiliate[] affiliateArray)
        {
            _affiliateArray = affiliateArray;
        }
        public async Task PopulateAffiliateDetailsAsync()
        {
            int first = 0;
            int last = _affiliateArray.Count() - 1;
            var queue = new Queue<int>(Enumerable.Range(first, last - first + 1));
            var numberOfAsyncWorkers = int.Parse(ConfigurationManager.AppSettings["NumberOfAsyncWorkers"]);

            await Task
                    .WhenAll((new Task[numberOfAsyncWorkers])
                                .Select(x => x = WorkerAsync(queue))
                                .ToArray());

        }
        private async Task WorkerAsync(Queue<int> queue)
        {
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                string aDetails = await (new HttpClient()
                                            .GetStringAsync(string
                                                            .Concat(ConfigurationManager.AppSettings["GetAffiliateInfoUrl"], 
                                                                    $"{_affiliateArray[i].AffiliteId.ToString()}")));

                var affiliateDetails = JsonConvert
                                        .DeserializeObject<AffiliateDetailObject>(aDetails);
                PopulateDetailFields(i, affiliateDetails);
            }
        }
        private void PopulateDetailFields(int i, AffiliateDetailObject affiliateDetails)
        {
            _affiliateArray[i].Website = affiliateDetails.Website; 
            _affiliateArray[i].Address = affiliateDetails.Address; 
            _affiliateArray[i].City = affiliateDetails.City;
            _affiliateArray[i].State = affiliateDetails.State;
            _affiliateArray[i].Zip = affiliateDetails.Zip;
            _affiliateArray[i].Country = affiliateDetails.Country;
            _affiliateArray[i].CfKids = affiliateDetails.CfKids;
            _affiliateArray[i].Phone = affiliateDetails.Phone;
            _affiliateArray[i].Courses = affiliateDetails.Courses;
        }
    }
}
