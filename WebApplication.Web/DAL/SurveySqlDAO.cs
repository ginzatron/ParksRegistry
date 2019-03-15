using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web
{
    public class SurveySqlDAO : ISurveyDAO
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

                    SqlCommand cmd = new SqlCommand(@"SELECT park.parkName, park.parkCode, COUNT(*) AS surveyCount
                                                    FROM park JOIN survey_result ON park.parkCode = survey_result.parkCode 
                                                    GROUP BY park.parkName, park.parkCode 
                                                    ORDER BY surveyCount DESC, park.parkName", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyViewModel model = ConvertReaderToPark(reader);
                        output.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return output;
        }

        private SurveyViewModel ConvertReaderToPark(SqlDataReader reader)
        {
            SurveyViewModel model = new SurveyViewModel();

            model.Code = Convert.ToString(reader["parkCode"]);
            model.ParkName = Convert.ToString(reader["parkName"]);
            model.SurveyCount = Convert.ToInt32(reader["surveyCount"]);

            return model;
        }

        public void SaveSurvey(SurveyViewModel newSurvey)
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
        }
    }
}