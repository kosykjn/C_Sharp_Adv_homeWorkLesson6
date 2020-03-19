using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWorkLesson6_1
{
    class TemperatureConverter
    {
        public double ConverToCelsius(int number)
        {
            return (number - 32) / 1.8;
        }

        public double ConverToFahrenheit(int number)
        {
            return number * 1.8 + 32;
        }

    }
}
