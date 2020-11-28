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
            var photos =  await marsRoverAPI.getMarsRoverPhotos(dates.getDates());
            await marsRoverAPI.DownloadMarsRovePhotos(photos);
        }
    }
}
