using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.Models;

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
    }
}