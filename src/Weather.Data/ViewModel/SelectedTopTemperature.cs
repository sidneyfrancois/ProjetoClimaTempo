using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.ViewModel
{
    public class SelectedTopTemperature
    {
        public string NomeCidade { get; set; }
        public decimal TemperatureMaxima { get; set; }
        public decimal TemperatureMinima { get; set; }
        public string Title { get; set; }
    }
}
