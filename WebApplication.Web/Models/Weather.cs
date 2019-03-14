using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public double LowTemp { get; set; }
        public double HighTemp { get; set; }
        public string Forecast { get; set; }

        public IDictionary<string, string> weatherImages = new Dictionary<string, string>()
        {
            {"cloudy", "cloudy.png" },
            { "partly cloudy","partlyCloudy.png"},
            { "rain","rain.png"},
            { "snow","snow.png"},
            { "sunny","sunny.png"},
            { "thunderstorms","thunderstorms.png"}
        };
    }
}
