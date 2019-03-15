using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web
{
    public class SurveySqlDAO : ISurveyDAO
    {
        /// <summary>
        /// database connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// returns a list of surveys in database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// converts sql data reader to survey object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private SurveyViewModel ConvertReaderToPark(SqlDataReader reader)
        {
            SurveyViewModel model = new SurveyViewModel();

            model.Code = Convert.ToString(reader["parkCode"]);
            model.ParkName = Convert.ToString(reader["parkName"]);
            model.SurveyCount = Convert.ToInt32(reader["surveyCount"]);

            return model;
        }

        /// <summary>
        /// adds new survey into database
        /// </summary>
        /// <param name="newSurvey"></param>
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