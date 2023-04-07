using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.ViewModel;
using System.Data.Entity;
using Weather.Data.Models;

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
            var topHottestFromDb = _context.PrevisoesDeClima
                                        .Include(x => x.Cidade)
                                        .OrderByDescending(x => x.TemperaturaMaxima)
                                        .Take(3).ToList();

            var ListTopHottest = new List<SelectedTopTemperature>();
            
            foreach (PrevisaoClima clima in topHottestFromDb)
            {
                ListTopHottest.Add(new SelectedTopTemperature()
                {
                    NomeCidade = clima.Cidade.Nome,
                    TemperatureMaxima = clima.TemperaturaMaxima,
                    TemperatureMinima = clima.TemperaturaMinima
                });
            }

            return View(ListTopHottest);
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