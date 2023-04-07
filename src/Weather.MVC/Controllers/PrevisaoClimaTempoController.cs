using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;

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
        public ActionResult GetMaxHoje(DateTime today)
        {
            var resultTop = _context.PrevisoesDeClima.OrderByDescending(x => x.TemperaturaMaxima).Take(3).ToList();
            return View(resultTop);
        }

        [HttpGet]
        [Route("min-hoje")]
        public ActionResult GetMinHoje(DateTime today)
        {
            var resultMin = _context.PrevisoesDeClima.OrderBy(x => x.TemperaturaMinima).Take(3).ToList();
            return View(resultMin);
        }
    }
}