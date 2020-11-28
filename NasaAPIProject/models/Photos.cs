using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject
{
    public class Photos
    {
        [JsonProperty("id")]
        string id { get; set; }

        [JsonProperty("sol")]
        int sol { get; set; }

        [JsonProperty("img_src")]
        public string img_src { get; set; }

        [JsonProperty("earth_date")]
        public string earthdate { get; set; }

        [JsonProperty("camera")]
        Camera camera { get; set; }

        [JsonProperty("rover")]
        Rover rover { get; set; }
    }

    public class Camera
    {
        [JsonProperty("id")]
        int id { get; set; }

        [JsonProperty("name")]
        string name { get; set; }

        [JsonProperty("rover_id")]
        int rover_id { get; set; }

        [JsonProperty("full_name")]
        string full_name { get; set; }
    }

    public class Rover
    {
        [JsonProperty("id")]
        int id { get; set; }

        [JsonProperty("name")]
        string name { get; set; }

        [JsonProperty("landing_date")]
        string landing_date { get; set; }

        [JsonProperty("launch_date")]
        string launch_date { get; set; }

        [JsonProperty("status")]
        string status { get; set; }

    }
}
