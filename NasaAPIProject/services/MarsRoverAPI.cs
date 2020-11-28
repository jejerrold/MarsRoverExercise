using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject
{
    class MarsRoverAPI
    {
        string BaseUrl = ConfigurationManager.AppSettings["MarsRoverAPI"];
        string APIKey = ConfigurationManager.AppSettings["APIKey"];
        List<Photos> myDeserializedClass = new List<Photos>();
        public async Task<List<Photos>> getMarsRoverPhotos(List<string> dates)
        {
            Console.WriteLine("Getting data from API.");
            foreach (var date in dates)
            {
                string PhotosURL = String.Format(BaseUrl + "?earth_date={0}&api_key={1}", date, APIKey);
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage res = await client.GetAsync(PhotosURL))
                        {
                            using (HttpContent content = res.Content)
                            {
                               
                                var data = await content.ReadAsStringAsync();
                                
                                if (data != null)
                                {
                                    JToken token = JObject.Parse(data);
                                    var photos = token.SelectToken("photos");
                                    var results = JsonConvert.DeserializeObject<List<Photos>>(photos.ToString());
                                    myDeserializedClass.AddRange(results);
                                }
                            }
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception Hit------------");
                    Console.WriteLine(exception);
                }
            }
            Console.WriteLine("Completed.");
            return myDeserializedClass;
        }
        public async Task DownloadMarsRovePhotos(List<Photos> photos)
        {
            FileDownload filedownload = new FileDownload();
            Console.WriteLine("Downloading Files... \n");
            foreach (var item in photos)
            {
               await filedownload.DownloadImage(item.img_src.Trim(), Constant.ImageFolder);
            }
            Console.WriteLine("All Files Downloaded Successfully..");
        }

    }
}
