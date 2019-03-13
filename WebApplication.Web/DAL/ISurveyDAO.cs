using System.Collections.Generic;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface ISurveyDAO
    {
        IList<SurveyViewModel> GetAllSurveys();

        int SaveSurvey(SurveyViewModel newSurvey);
    }
}