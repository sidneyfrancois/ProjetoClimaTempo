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
    }
}