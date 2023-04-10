using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.ViewModel;
using System.Data.Entity;
using Weather.Data.Models;
using System.Globalization;
using Weather.MVC.Repository;

namespace Weather.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        private readonly PrevisaoClimaRepository _repositoryPrevisaoClima;
        private readonly CidadeRepository _repositoryCidade;
        private readonly CultureInfo culture = new CultureInfo("pt-BR");

        public HomeController(MyDbContext context, CidadeRepository repositoryCidade, PrevisaoClimaRepository repositoryPrevisaoClima)
        {
            _context = context;
            _repositoryCidade = repositoryCidade;
            _repositoryPrevisaoClima = repositoryPrevisaoClima;
        }

        public ActionResult Index()
        {
            var allCities = _repositoryCidade.GetAllCitiesForDropDownList();

            return View(allCities);
        }

        public PartialViewResult TopThreeHottestTemperatures()
        {
            var topHottest = _repositoryPrevisaoClima.GetPrevisaoClimaTop3("hottest", 3);

            var ListTopHottest = new List<SelectedTopTemperature>();

            foreach (PrevisaoClima clima in topHottest)
            {
                ListTopHottest.Add(new SelectedTopTemperature()
                {
                    NomeCidade = clima.Cidade.Nome,
                    TemperatureMaxima = clima.TemperaturaMaxima,
                    TemperatureMinima = clima.TemperaturaMinima,
                    Title = "quentes"
                });
            }

            return PartialView("TopThreeTemperatures", ListTopHottest);
        }

        public PartialViewResult TopThreeColdestTemperatures()
        {
            var topColdest = _repositoryPrevisaoClima.GetPrevisaoClimaTop3("coldest", 3);

            var listTopColdest = new List<SelectedTopTemperature>();

            foreach (PrevisaoClima clima in topColdest)
            {
                listTopColdest.Add(new SelectedTopTemperature()
                {
                    NomeCidade = clima.Cidade.Nome,
                    TemperatureMaxima = clima.TemperaturaMaxima,
                    TemperatureMinima = clima.TemperaturaMinima,
                    Title = "frias"
                });
            }

            return PartialView("TopThreeTemperatures", listTopColdest);
        }

        public ActionResult ReportSevenDaysWeather(int? cidadeId)
        {
            if (cidadeId == null)
            {
                var empty = new List<WeatherReportViewModel>();
                return PartialView(empty);
            }

            var reportSevenDaysDB = _repositoryPrevisaoClima.GetReportSevenDays(cidadeId);

            var reportSevenDaysViewModel = new List<WeatherReportViewModel>();

            foreach (PrevisaoClima clima in reportSevenDaysDB)
            {
                reportSevenDaysViewModel.Add(new WeatherReportViewModel()
                {
                    Cidade = clima.Cidade.Nome,
                    Clima = clima.Clima,
                    TemperaturaMaxima = clima.TemperaturaMaxima,
                    TemperaturaMinima = clima.TemperaturaMinima,
                    DayOfWeek = culture.DateTimeFormat.DayNames[(int)clima.DataPrevisao.DayOfWeek]
            });
            }

            return PartialView(reportSevenDaysViewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}