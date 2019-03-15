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

        [TestMethod]
        public void GetParkByCode_TWNG()
        {
            ParkSqlDAO parkSqlDAO = new ParkSqlDAO(ConnectionString);
            Park park = parkSqlDAO.GetParkByCode("TWNG");

            Assert.AreEqual(park.Code, "TWNG");
        }
    }
}
