using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Tests.DAL;
using WebApplication.Web;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests
{
    [TestClass]
    public class SurveySqlDAOTests : CapstoneTests
    {

        [TestMethod]
        public void GetAllSurveysReturnsOneSurvey()
        {
            SurveySqlDAO surveyDAO = new SurveySqlDAO(ConnectionString);
            IList<SurveyViewModel> surveys = surveyDAO.GetAllSurveys();

            Assert.AreEqual(1, surveys.Count);
        }
    }
}
