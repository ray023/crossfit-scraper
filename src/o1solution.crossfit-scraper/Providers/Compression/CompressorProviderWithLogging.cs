using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.Compression
{
    public class CompressorProviderWithLogging : ICompressorProvider
    {
        private readonly CompressorProvider _provider;

        public CompressorProviderWithLogging()
        {
            _provider = new CompressorProvider();
        }
        public void ZipIt()
        {
            WindowsEventLogger.
                WriteEventLogEntry($"Zipping File", EventLogEntryType.Information);

            _provider.ZipIt();
        }
    }
}
