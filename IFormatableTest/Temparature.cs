using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IFormattableTest
{
    class Temparature : IFormattable
    {
        private decimal temparature;
        public decimal Celsius
        {
            get
            {
                return temparature;
            }
        }
        public decimal Fahrenheyt
        {
            get
            {
                return temparature * 9 / 5 + 32;
            }
        }
        public decimal Kelvin
        {
            get
            {
                return temparature + 273.15m;
            }
        }
            


        public Temparature(decimal temparature)
        {
            this.temparature = temparature;
        }

        public override string ToString()
        {
            return ToString("Celsius", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(format))
                format = "Celsius";

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToLower())
            {
                case "celsius":
                    result = string.Format("{0} C", Celsius);
                    break;
                case "fahrenheyt":
                    result = string.Format("{0} F", Fahrenheyt);
                    break;
                case "kelvin":
                    result = string.Format("{0} K", Kelvin);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Формат {0} не существует в запрошенном представлении.", format);
            }

            return result;
        }
    }
}
