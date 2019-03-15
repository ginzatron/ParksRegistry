using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Tests.DAL;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests
{
    [TestClass]
    public class ParkSqlDAOTests : CapstoneTests 
    {
        [TestMethod]
        public void GetAllParksReturnsOnePark()
        {
            ParkSqlDAO parkDAO = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = parkDAO.GetAllParks();

            Assert.AreEqual(1, parks.Count);
        }
    }
}
