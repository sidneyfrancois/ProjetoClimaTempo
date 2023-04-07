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
            return View();
        }

        public PartialViewResult TopThreeHottestTemperatures()
        {
            DateTime today = new DateTime(2023, 02, 23);

            var topHottestFromDb = _context.PrevisoesDeClima
                                        .Include(x => x.Cidade)
                                        .Where(c => c.DataPrevisao.Equals(today))
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

            return PartialView("TopThreeTemperatures", ListTopHottest);
        }

        public PartialViewResult TopThreeColdestTemperatures()
        {
            DateTime today = new DateTime(2023, 02, 23);

            var topColdestFromDb = _context.PrevisoesDeClima
                                        .Include(x => x.Cidade)
                                        .Where(c => c.DataPrevisao.Equals(today))
                                        .OrderBy(x => x.TemperaturaMaxima)
                                        .Take(3).ToList();

            var listTopColdest = new List<SelectedTopTemperature>();

            foreach (PrevisaoClima clima in topColdestFromDb)
            {
                listTopColdest.Add(new SelectedTopTemperature()
                {
                    NomeCidade = clima.Cidade.Nome,
                    TemperatureMaxima = clima.TemperaturaMaxima,
                    TemperatureMinima = clima.TemperaturaMinima
                });
            }

            return PartialView("TopThreeTemperatures", listTopColdest);
        }

        public PartialViewResult ReportSevenDaysWeather(Cidade cidade)
        {
            DateTime today = new DateTime(2023, 02, 23);
            DateTime fim = today.AddDays(7);

            var reportSevenDaysDB = _context.PrevisoesDeClima
                                            .Where(
                                                c => c.DataPrevisao > today && 
                                                c.DataPrevisao <= fim &&
                                                c.CidadeId == cidade.Id)
                                            .ToList();

            var reportSevenDays = new List<WeatherReportViewModel>();

            foreach (PrevisaoClima clima in reportSevenDaysDB)
            {
                reportSevenDays.Add(new WeatherReportViewModel()
                {
                    Clima = clima.Clima,
                    TemperaturaMaxima = clima.TemperaturaMaxima,
                    TemperaturaMinima = clima.TemperaturaMinima
                });
            }

            return PartialView(reportSevenDays);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}