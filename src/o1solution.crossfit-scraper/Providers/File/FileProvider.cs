using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o1solution.crossfitscraper.Providers.MySql;

namespace o1solution.crossfitscraper.Providers.File
{
    public class FileProvider : IFileProvider
    {
        private readonly IMySqlProvider _serverProvider;

        public FileProvider()
        {
            _serverProvider = Factory.GetServerProvider();
        }
        public void CreateIt()
        {

            using (StreamWriter outputFile = new StreamWriter(new FileStream(Factory.GetFullFileName(), FileMode.Create)))
                outputFile
                    .WriteLine(string.Concat(_serverProvider
                                                .GetEventPopulateSql(Factory
                                                                     .GetEventProvider()
                                                                     .GetCurrentEventList()),
                                              _serverProvider
                                                .GetAffiliatePopulateSql(Factory
                                                                        .GetAffiliateProvider()
                                                                        .GetCurrentAffiliateList())));
        }
    }
}
