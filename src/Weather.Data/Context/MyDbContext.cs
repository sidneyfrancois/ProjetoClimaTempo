using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.Models;

namespace Weather.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DefaultConnection")
        {}

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<PrevisaoClima> PrevisoesDeClima { get; set; }
    }
}
