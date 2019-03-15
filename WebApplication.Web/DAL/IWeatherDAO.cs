using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IWeatherDAO
    {
        /// <summary>
        /// Returns a specific 5 days of forecast for a specific park
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IList<Weather> Get5DayForecast(string code);
    }
}
