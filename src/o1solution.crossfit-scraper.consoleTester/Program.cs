using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace o1solution.crossfitscraper.consoleTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                WindowsEventLogger
                    .WriteEventLogEntry("Launched Daily Job", EventLogEntryType.Information);

                Factory.Intialize();

                Factory
                    .GetFileProvider()
                    .CreateIt();

                Factory
                    .GetCompressorProvider()
                    .ZipIt();

                Factory
                    .GetFtpProvider()
                    .SendIt();
                
            }
            catch (Exception ex)
            {

                WindowsEventLogger
                    .WriteEventLogEntry($"Message:  {ex.Message}  Data:  {ex.Data}", EventLogEntryType.Error);
                MessageBox.Show("CrossFit Scraper Error.  See Event Log", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
