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
        public PrevisaoClimaRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<PrevisaoClima> GetAll()
        {
            var allPrevisaoClima = _context.PrevisoesDeClima.Include(x => x.Cidade).ToList();
            return allPrevisaoClima;
        }

        public List<PrevisaoClima> GetPrevisaoClimaTop3(
            string hottestOrColdest, 
            int minTake
            )
        {
            DateTime today = new DateTime(2023, 02, 23);

            if (hottestOrColdest == "hottest")
            {
                return _context.PrevisoesDeClima
                            .Include(x => x.Cidade)
                            .Where(c => c.DataPrevisao.Equals(today))
                            .OrderByDescending(x => x.TemperaturaMaxima)
                            .Take(minTake).ToList();
            }

            if (hottestOrColdest == "coldest")
            {
                return _context.PrevisoesDeClima
                            .Include(x => x.Cidade)
                            .Where(c => c.DataPrevisao.Equals(today))
                            .OrderBy(x => x.TemperaturaMaxima)
                            .Take(minTake).ToList();
            }

            return new List<PrevisaoClima>();
        }

        public List<PrevisaoClima> GetReportSevenDays(int? cidadeId)
        {
            DateTime today = new DateTime(2023, 02, 21);
            DateTime endDate = today.AddDays(7);

            var reportSevenDays = _context.PrevisoesDeClima
                                    .Include(x => x.Cidade)
                                    .Where(
                                        c => c.DataPrevisao > today &&
                                                c.DataPrevisao <= endDate &&
                                                c.CidadeId == cidadeId)
                                    .ToList();

            return reportSevenDays;
        }
    }
}