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
        public MyDbContext() : base("ConnectionString")
        {}

        public DbSet<SingleWeather> Wheaters { get; set; }
    }
}
