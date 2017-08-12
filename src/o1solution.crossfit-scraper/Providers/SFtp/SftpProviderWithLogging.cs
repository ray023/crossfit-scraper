using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Providers.SFtp
{
    public class SftpProviderWithLogging : ISFtpProvider
    {
        private readonly SftpProvider _provider;

        public SftpProviderWithLogging()
        {
            _provider = new SftpProvider();
        }
        public string SendIt()
        {
            WindowsEventLogger.WriteEventLogEntry("Ftp File", EventLogEntryType.Information);
            var returnVal = _provider.SendIt();
            WindowsEventLogger.WriteEventLogEntry($"Return value:  {returnVal}", EventLogEntryType.Information);

            return returnVal;
        }
    }
}
