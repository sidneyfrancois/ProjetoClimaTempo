using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Data.Context;
using Weather.Data.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Weather.MVC.Repository
{
    public class PrevisaoClimaRepository
    {
        private readonly MyDbContext _context;
        public PrevisaoClimaRepository()
        {
            _context = new MyDbContext();
        }

        public List<PrevisaoClima> GetAll()
        {
            var allPrevisaoClima = _context.PrevisoesDeClima.Include(x => x.Cidade).ToList();
            return allPrevisaoClima;
        }

        public List<PrevisaoClima> GetPrevisaoClimaTop3(
            Expression<Func<PrevisaoClima, bool>> expressionWhere, 
            Expression<Func<PrevisaoClima, object>> orderTempMaxOrMin, 
            int minTake
        )
        {
            var topTemperatures = _context.PrevisoesDeClima
                                        .Include(x => x.Cidade)
                                        .Where(expressionWhere)
                                        .OrderBy(orderTempMaxOrMin)
                                        .Take(minTake).ToList();
            return topTemperatures;
        }
    }
}