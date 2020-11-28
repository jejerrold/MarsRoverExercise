using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            MarsRoverAPI marsRoverAPI = new MarsRoverAPI();
           
            Dates dates = new Dates();
            var selecteddates = dates.getDates();
            var photos =  await marsRoverAPI.getMarsRoverPhotos(selecteddates);
           // await marsRoverAPI.DownloadMarsRovePhotos(photos);
            MarsRoverHtml marsRoverHtml = new MarsRoverHtml(photos, selecteddates);
            marsRoverHtml.CreateMarsRoverWebPage();
            System.Diagnostics.Process.Start(String.Format("ViewImagesTest.html"));
        }
    }
}
