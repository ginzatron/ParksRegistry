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

        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();

            park.Code = Convert.ToString(reader["parkCode"]);
            park.Name = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Description = Convert.ToString(reader["parkDescription"]);

            return park;
        }
    }
}
