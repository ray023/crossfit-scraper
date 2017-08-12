using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.File
{
    public class FileProviderWithLogging : IFileProvider
    {
        private readonly FileProvider _provider;

        public FileProviderWithLogging()
        {
            _provider = new FileProvider();
        }
        public void CreateIt()
        {
            WindowsEventLogger.WriteEventLogEntry($"Write File {Factory.GetFullFileName()}", EventLogEntryType.Information);
            _provider.CreateIt();
        }
    }
}
