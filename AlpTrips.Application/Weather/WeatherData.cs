using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Weather
{
    public class WeatherData
    {
            public DateTime Date { get; set; }
            public double MaxTemperature { get; set; }
            public double MinTemperature { get; set; }
            public string Condition { get; set; }
            public string IconUrl { get; set; }
            public double WindStrength { get; set; }
            public double Precipitation { get; set; }
        }

    }

