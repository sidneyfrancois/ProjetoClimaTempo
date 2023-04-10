﻿using System;
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

        public HomeController()
        {
            _context = new MyDbContext();
            _repositoryPrevisaoClima = new PrevisaoClimaRepository();
            _repositoryCidade = new CidadeRepository();
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
                    TemperatureMinima = clima.TemperaturaMinima
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
                    TemperatureMinima = clima.TemperaturaMinima
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

            DateTime today = new DateTime(2023, 02, 21);
            DateTime fim = today.AddDays(7);

            var reportSevenDaysDB = _context.PrevisoesDeClima
                                            .Include(x => x.Cidade)
                                            .Where(
                                                c => c.DataPrevisao > today && 
                                                c.DataPrevisao <= fim &&
                                                c.CidadeId == cidadeId)
                                            .ToList();

            var reportSevenDays = new List<WeatherReportViewModel>();

            foreach (PrevisaoClima clima in reportSevenDaysDB)
            {
                reportSevenDays.Add(new WeatherReportViewModel()
                {
                    Cidade = clima.Cidade.Nome,
                    Clima = clima.Clima,
                    TemperaturaMaxima = clima.TemperaturaMaxima,
                    TemperaturaMinima = clima.TemperaturaMinima,
                    DayOfWeek = culture.DateTimeFormat.DayNames[(int)clima.DataPrevisao.DayOfWeek]
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