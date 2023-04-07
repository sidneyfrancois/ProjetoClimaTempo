using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.ViewModel;
using System.Data.Entity;

namespace Weather.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        public HomeController()
        {
            _context = new MyDbContext();
        }

        public ActionResult Index()
        {
            var resultTopThreeHottest = new TopMaxHottestViewModel();
            resultTopThreeHottest.TopThreeHottest = _context.PrevisoesDeClima.Include(x => x.Cidade).OrderByDescending(x => x.TemperaturaMaxima).Take(3).ToList();
            return View(resultTopThreeHottest);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}