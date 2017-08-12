using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o1solution.crossfitscraper.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace o1solution.crossfitscraper.Providers.Events
{
    public class EventProvider : IEventProvider
    {
        public List<Event> GetCurrentEventList()
        {
            return JsonConvert
                    .DeserializeObject<List<Event>>(
                        new HttpClient()
                            .GetStringAsync(ConfigurationManager.AppSettings["GetAllEventsUrl"])
                            .Result);
        }
    }
}
