using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        /// <summary>
        /// connection string to database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// return list of all weathers for a specific park
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IList<Weather> Get5DayForecast(string code)
        {
            IList<Weather> weathers = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE weather.parkCode = @code ", conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = ConvertReaderToWeather(reader);
                        weathers.Add(weather);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return weathers;
        }

        /// <summary>
        /// convert sql data reader to weather object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Weather ConvertReaderToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather();

            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.LowTemp = Convert.ToInt32(reader["low"]);
            weather.HighTemp = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);

            return weather;
        }
    }
}
