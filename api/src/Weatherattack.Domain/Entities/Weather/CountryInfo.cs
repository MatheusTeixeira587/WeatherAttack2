using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Domain.Entities.Weather
{
    public class CountryInfo
    {
        public CountryInfo(string countryName)
        {
            CountryName = countryName;
        }

        public CountryInfo()
        {
        }

        public string CountryName { get; private set; }
    }
}
