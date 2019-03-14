using System.Collections.Generic;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface ISurveyDAO
    {
        IList<SurveyViewModel> GetAllSurveys();

        void SaveSurvey(SurveyViewModel newSurvey);
    }
}