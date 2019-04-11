using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IFormatProviderTest
{
    class ComplexTestFormater : ICustomFormatter, IFormatProvider
    {
        ///Форматирует вывод экземпляра Complex
        ///ICustomFormatter и IFormatProvider можно использовать для создание форматированного вывода обьекта в котором нельзя переопределить втроенный форматированный вывод
        ///ICustomFormatter - для создание своих форматов

        //Реализация ICustomFormatter
        public string Format(string format, object value, IFormatProvider formatProvider)
        {
            ///Будет вызван вместо ToString

            //Проверка возможности приведения типа аргумента value к Complex
            if ((value is Complex) == false)
            {
                //Если ложь : возврат строкового представления по умолчанию
                return GetDefaultFormat(value, formatProvider);
            }

            //Проверка допустимого значения аргумента формат
            if (format.ToLower() != "test")
            {
                //Если ложь : возврат строкового представления по умолчанию
                return GetDefaultFormat(value, formatProvider);
            }
            //Приведение типа аргумента value к типу Complex
            Complex complexNumber = (Complex)value;
            //Создания и возврат форматированой строки на основании открытых свойств экземпляра Complex  и форматера по умолчанию
            StringBuilder formatStringComplex = new StringBuilder();
            formatStringComplex.AppendFormat(CultureInfo.CurrentCulture, "{0:F2}", complexNumber.Real);
            formatStringComplex.Append(" : ");
            formatStringComplex.AppendFormat(CultureInfo.CurrentCulture, "{0:F2}", complexNumber.Imaginary);

            return formatStringComplex.ToString();
        }

        private string GetDefaultFormat(object value, IFormatProvider formatProvider)
        {
            string formatStringValue = string.Empty;
            //Проверка возможности приведения типа аргумента value к IFormattable
            if (value is IFormattable)
            {
                //Если истниа : возврат форматированной строки IFormattable.ToString с форматом по умолчанию
                formatStringValue = ((IFormattable)value).ToString("", formatProvider);
            }
            else
            {
                //Если ложь : возврат неформатированной строки ToString
                formatStringValue = value.ToString();
            }

            return formatStringValue;
        }

        //Реализация IFormatProvider. Неявно вызывается методом string.Format
        public object GetFormat(Type formatType)
        {
            ///Исходя из логикик реализации метод IFormatProvider.GetFormat  неявно вызывается или IFormatter.ToString или подобных ему для получения обьекта в котором есть метод ICustomFormatter.Format(string, object, IFormatProvider)
            ///Возвращает обьект для форматирования
            ///Позже будет вызван метод Format(string, object, IFormatProvider) вернувшегося экземпляра и ему в третий аргумент будет передан он сам 

            //Проверить фргумент formatType на принадлежность к ICustomFormatter
            if ( formatType == typeof(ICustomFormatter) )
            {
                //Если истина : вернуть себя
                return this;
            }
            else
            {
                //Если ложь : вернуть форматер по умолчанию
                return CultureInfo.CurrentCulture.GetFormat(formatType);
            }

        }
    }

    struct Complex : IFormattable
    {
        //Обьявление переменных реальной и мнимой части комплексного числа
        private double real;
        private double imaginary;
        //Обьявление открытых для чтения свойств доступа к реальной и мнимой части числа 
        public double Real { get { return real; } }
        public double Imaginary { get { return imaginary; } }
        //Конструктор инициализрует поля аргументами
        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        //Реализация IFormattable
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder formatString = new StringBuilder();
            //Аргумент format игнорируется
            formatString.Append("(");
            formatString.AppendFormat(formatProvider, "\t{0:F2}", real);
            formatString.Append(" : ");
            formatString.AppendFormat(formatProvider, "{0:F2}\t", imaginary);
            formatString.Append(")");

            return formatString.ToString();
        }
    }
}
