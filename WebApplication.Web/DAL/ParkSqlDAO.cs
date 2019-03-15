using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        /// <summary>
        /// database connection string
        /// </summary>
        private string connectionString;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// method to get all parks from database
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park",conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parks;
        }

        /// <summary>
        /// reteurn single park from database identified by 4 letter code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Park GetParkByCode(string code)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE park.parkCode = @code", conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        park = ConvertReaderToPark(reader);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return park;
        }

        /// <summary>
        /// converts sqldata reader to a park object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();

            park.Code = Convert.ToString(reader["parkCode"]);
            park.Name = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Description = Convert.ToString(reader["parkDescription"]);
            park.Quote = Convert.ToString(reader["inspirationalQuote"]);
            park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.Acerage = Convert.ToInt32(reader["acreage"]);
            park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
            park.Miles = Convert.ToInt32(reader["milesOfTrail"]);
            park.Campsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.EntryFee = Convert.ToInt32(reader["entryFee"]);
            park.NumberAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;
        }
    }
}
