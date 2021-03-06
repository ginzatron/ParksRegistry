﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetAllParks();
            return View(parks);
        }  
        
        public IActionResult Detail(string code,string scale)
        {
            if (scale == null)
            {
                // Get the scale from the session.
                scale = HttpContext.Session.GetString("scale");

                if (scale == null)
                {
                    scale = "f";
                }

                // If it doesn't exist in the session, default to "F"
            }
            else
            {
                //Scales was passed in, save it in session
                HttpContext.Session.SetString("scale", scale);
            }

            ViewData["scale"] = scale;

            Park park = parkDAO.GetParkByCode(code);
            park.weathers = weatherDAO.Get5DayForecast(code);

            return View(park);
        }

        [HttpGet]
        public IActionResult Survey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                surveyDAO.SaveSurvey(model);

                return RedirectToAction("FavoriteParks");
            }
            return View(model);
        }

        public IActionResult FavoriteParks()
        {
            IList<SurveyViewModel> surveys = surveyDAO.GetAllSurveys();
            return View(surveys);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
