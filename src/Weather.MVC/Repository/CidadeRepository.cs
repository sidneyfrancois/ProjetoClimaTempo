using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Data.Context;
using Weather.Data.Models;

namespace Weather.MVC.Repository
{
    public class CidadeRepository
    {
        private readonly MyDbContext _context;
        public CidadeRepository()
        {
            _context = new MyDbContext();
        }

        public SelectList GetAllCitiesForDropDownList()
        {
            var allCities = _context.Cidades.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            });

            return new SelectList(allCities, "Value", "Text");
        }
    }
}