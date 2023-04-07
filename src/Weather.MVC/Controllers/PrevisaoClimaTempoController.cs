using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.Models;

namespace Weather.MVC.Controllers
{
    [RoutePrefix("clima")]
    public class PrevisaoClimaTempoController : Controller
    {
        private readonly MyDbContext _context;

        public PrevisaoClimaTempoController()
        {
            _context = new MyDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("cidades")]
        public ActionResult GetAllCidades()
        {
            var result = _context.Cidades.ToList();
            return View(result);
        }

        [HttpGet]
        [Route("estados")]
        public ActionResult GetAllEstados()
        {
            var result = _context.Estados.ToList();
            return View(result);
        }

        [HttpGet]
        [Route("climas")]
        public ActionResult GetAllClimas()
        {
            var result = _context.PrevisoesDeClima.ToList();
            return View(result);
        }

        [HttpGet]
        [Route("max-hoje")]
        public ActionResult GetTopMaxHottest(DateTime today)
        {
            var resultTop = _context.PrevisoesDeClima.OrderByDescending(x => x.TemperaturaMaxima).Take(3).ToList();
            return View(resultTop);
        }

        [HttpGet]
        [Route("min-hoje")]
        public ActionResult GetTopMinColdest(DateTime today)
        {
            var resultMin = _context.PrevisoesDeClima.OrderBy(x => x.TemperaturaMinima).Take(3).ToList();
            return View(resultMin);
        }

        [HttpGet]
        [Route("clima-hoje")]
        public ActionResult GetClimaHoje(Cidade cidade)
        {
            DateTime today = new DateTime(2023, 02, 23);
            DateTime fim = today.AddDays(7);

            var result = _context.PrevisoesDeClima.Where(c => c.DataPrevisao > today && c.DataPrevisao <= fim && c.CidadeId == cidade.Id).ToList();
            return View(result);
        }
    }
}