using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class Month
    {
        public string MonthName
        {
            get
            {
                return _month.ToString();
            }
        }
        private int _countDays;
        public int CountDays
        {
            get
            {
                return _countDays;
            }
        }
        public int MonthNumber
        {
            get
            {
                return ((int)_month);
            }
        }
        private Monthes _month;

        public Month(Monthes month)
        {
            _month = month;
            _countDays = GetCountMonthDays();
        }

        private int GetCountMonthDays()
        {
            int days;
            if( ( (int)_month ) % 2 != 0)
            {
                days = 31;
            }
            else if(((int)_month) == 8)
            {
                days = 31;
            }
            else if (((int)_month) == 2)
            {
                days = 28;
            }
            else
            {
                days = 30;
            }

            return days;
        }
        public override string ToString()
        {
            return string.Format("MonthName: {1}, MonthNumber: {2}", this.GetType(), this.MonthName, this.MonthNumber);
        }
    }

    public enum Monthes
    {
        January = 1,
        February,
        Mart,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    
}
