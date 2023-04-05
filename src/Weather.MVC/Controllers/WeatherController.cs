using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.Models;
using Weather.Data.ViewModel;

namespace Weather.MVC.Controllers
{
    [RoutePrefix("weather")]
    public class WeatherController : Controller
    {
        private readonly MyDbContext _context;

        public WeatherController()
        {
            _context = new MyDbContext();
        }

        // GET: Weather
        [HttpGet]
        public ActionResult GetAllWeathers()
        {
            var result = _context.Wheaters.ToList();
            return View(result);
        }

        [HttpPost]
        public ActionResult AddWeather(AddWeatherViewModel viewModel)
        {
            var newWeather = new SingleWeather
            {
                Id = Guid.NewGuid(),
                Temperature = viewModel.Temperature,
                Type = viewModel.Type
            };

            _context.Wheaters.Add(newWeather);
            _context.SaveChanges();

            return View(newWeather);
        }
    }
}