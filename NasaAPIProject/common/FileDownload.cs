using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject
{
    class FileDownload
    {
     

        public async Task DownloadImage(string Url, string filefolder)
        {
            var AppSettings = ConfigurationManager.AppSettings;
            
            createFolder(filefolder);
            using (WebClient client = new WebClient())
            {
                var filename = getFileName(Url);
                string outputFolder = String.Format(filefolder + "\\" + filename);
                await client.DownloadFileTaskAsync(new Uri(Url), outputFolder.Replace(@"\\", @"\"));
                Console.WriteLine("File {0} download completed. \n", filename);
                client.Dispose();
            }
        }

        public string getFileName(string url)
        {
           
            Uri uri = new Uri(url);
            string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
            return filename;
        }

        private void createFolder(string filePath)
        {
            Directory.CreateDirectory(filePath);
        }
    }
}
