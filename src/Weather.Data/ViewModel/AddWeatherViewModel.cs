using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.Models;

namespace Weather.Data.ViewModel
{
    public class AddWeatherViewModel
    {
        public float Temperature { get; set; }
        public TypeWeather Type { get; set; }
    }
}
