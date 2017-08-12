using System.Configuration;
using System.IO;
using System.Net;

namespace o1solution.crossfitscraper.Providers.SFtp
{
    public class SftpProvider : ISFtpProvider
    {
        public string SendIt()
        {
            var host = ConfigurationManager.AppSettings["Host"];
            var zipFile = Factory.GetZipFile();

            Renci.SshNet.SftpClient sftpClient = new Renci.SshNet
                                                        .SftpClient(host,
                                                                    ConfigurationManager.AppSettings["FtpUserName"],
                                                                    ConfigurationManager.AppSettings["FtpUserPass"]);
            sftpClient.Connect();

            sftpClient
                .ChangeDirectory(ConfigurationManager.AppSettings["WorkingDirectory"]);

            using (var fileStream = new FileStream(zipFile, FileMode.Open))
            {
                sftpClient.BufferSize = 4 * 1024; // bypass Payload error large files
                sftpClient.UploadFile(fileStream, Path.GetFileName(zipFile));
            }

            return new WebClient()
                            .DownloadString(ConfigurationManager.AppSettings["UpdateDatabaseUrl"]);

        }
    }
}
