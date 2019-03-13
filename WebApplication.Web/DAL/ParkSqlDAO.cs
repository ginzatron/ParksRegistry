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
        private string connectionString;
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

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

        public Park GetParkByCode(int code)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park parks = ConvertReaderToPark(reader);
                        park.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return park;
        }

        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();

            park.Code = Convert.ToString(reader["parkCode"]);
            park.Name = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Description = Convert.ToString(reader["parkDescription"]);
            park.Quote = Convert.ToString(reader["inspirationalQuote"]);
            park.QuoteSource = Convert.ToString(reader["inspirationQuoteSource"]);
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
