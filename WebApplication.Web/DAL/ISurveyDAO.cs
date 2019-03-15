using System.Collections.Generic;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// returns all surveys from database
        /// </summary>
        /// <returns></returns>
        IList<SurveyViewModel> GetAllSurveys();

        /// <summary>
        /// method to save survey to database
        /// </summary>
        /// <param name="newSurvey"></param>
        void SaveSurvey(SurveyViewModel newSurvey);
    }
}