using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.ViewModel
{
    public class WeatherReportViewModel
    {
        public string Cidade { get; set; }
        public string Clima { get; set; }
        public string DayOfWeek { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
    }
}
