using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web
{
    internal class SurveySqlDAO : ISurveyDAO
    {
        private readonly string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<SurveyViewModel> GetAllSurveys()
        {
            IList<SurveyViewModel> output = new List<SurveyViewModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return output;
        }

        public int SaveSurvey(SurveyViewModel newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.Code);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.Email);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);
                    cmd.Parameters.AddWithValue("@review_date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return 0;
        }
    }
}