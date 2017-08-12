using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.Compression
{
    public class CompressorProvider : ICompressorProvider
    {
        public void ZipIt()
        {

            var zipDirectoryAndFile = Factory.GetZipFile();

            using (var zip = ZipFile.Open(zipDirectoryAndFile, ZipArchiveMode.Create))
                ZipFileExtensions
                    .CreateEntryFromFile(zip,
                                         Factory.GetFullFileName(),
                                         ConfigurationManager.AppSettings["MySqlDailyUpdateFileName"]);
        }
        

        
    }
}
