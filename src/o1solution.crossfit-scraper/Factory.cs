using o1solution.crossfitscraper.Providers.Affiliates;
using o1solution.crossfitscraper.Providers.Compression;
using o1solution.crossfitscraper.Providers.Events;
using o1solution.crossfitscraper.Providers.File;
using o1solution.crossfitscraper.Providers.MySql;
using o1solution.crossfitscraper.Providers.SFtp;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;


namespace o1solution.crossfitscraper
{
    public static class Factory
    {
        public static ICompressorProvider GetCompressorProvider()
        {
            return new CompressorProviderWithLogging();
        }
        public static IAffiliateProvider GetAffiliateProvider()
        {
            return new AffiliateProviderWithLogging();
        }
        public static IEventProvider GetEventProvider()
        {
            return new EventProviderWithLogging();
        }
        public static IMySqlProvider GetServerProvider()
        {
            return new MySqlProviderWithLogging();
        }
        public static IFileProvider GetFileProvider()
        {
            return new FileProviderWithLogging();
        }
        public static ISFtpProvider GetFtpProvider()
        {
            return new SftpProviderWithLogging();
        }
        public static void Intialize()
        {
            var sqlFile = GetFullFileName();
            if (File.Exists(sqlFile))
                File.Delete(sqlFile);

            var zipFile = GetZipFile();
            if (File.Exists(zipFile))
                File.Delete(zipFile);

        }
        public static string GetZipFile()
        {
            return Path.Combine(Path.GetTempPath(),
                                ConfigurationManager.AppSettings["ZipFile"]);
        }
        public static string GetFullFileName()
        {
            return Path.Combine(Path.GetTempPath(), 
                                ConfigurationManager.AppSettings["MySqlDailyUpdateFileName"]);
        }
    }
}
