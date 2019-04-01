using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class MonthesCollection : ICollection<Month>
    {
        int _count;
        //int _currentPosition;
        Month[] _monthes;

        public MonthesCollection()
        {
            InititalizeArray();
        }

        public MonthesCollection(Month[] monthes)
        {
            this._monthes = monthes;
            this._count = this._monthes.Length;
        }

        public MonthesCollection this[string monthName]
        {
            get
            {
                //var query = (from Month m in _monthes //При обработке значений массива null выпадает исключение
                //                 //TODO: m == null
                //             where m.MonthName == monthName
                //             select m).ToArray<Month>();
                List<Month> list = new List<Month>();

                for (int i = 0; i <= _count - 1; i++)
                {
                    if (_monthes[i].MonthName.Equals(monthName))
                    {
                        list.Add(_monthes[i]);
                    }
                }
                return new MonthesCollection(list.ToArray<Month>());
            }
        }

        public void InitializeCollection()
        {
            if (_monthes == null)
                InititalizeArray();

            this.Add(new Month(Monthes.January));
            this.Add(new Month(Monthes.February));
            this.Add(new Month(Monthes.Mart));
            this.Add(new Month(Monthes.April));
            this.Add(new Month(Monthes.May));
            this.Add(new Month(Monthes.June));
            this.Add(new Month(Monthes.July));
            this.Add(new Month(Monthes.August));
            this.Add(new Month(Monthes.September));
            this.Add(new Month(Monthes.October));
            this.Add(new Month(Monthes.November));
            this.Add(new Month(Monthes.December));
        }
        void InititalizeArray()
        {
            this._monthes = new Month[2];
            this._count = 0;
            //this._currentPosition = -1;
        }

        public int Count { get { return _count; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(Month item)
        {
            _count++;
            
            if (_monthes.Length < _count)
                IncreaseArray();
            _monthes[_count - 1] = item;
        }

        void IncreaseArray()
        {
            Month[] temp = new Month[_monthes.Length * 2];
            _monthes.CopyTo(temp, 0);
            _monthes = temp;
        }

        public void Clear()
        {
            InititalizeArray();
        }

        public bool Contains(Month item)
        {
            if (_monthes.Contains<Month>(item))
                return true;

            return false;
        }

        public void CopyTo(Month[] array, int arrayIndex)
        {
            _monthes.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Month> GetEnumerator()
        {
           for (int i = 0; i <= _count-1; i++)
            {
                yield return _monthes[i];
            }
            //yield break; //Используется для прерывания yield return если есть вероятность IndexOutOfRangeException. При ввызове yield return не возвратит исключения.
        }

        public bool Remove(Month item)
        {
            bool result = false;

            for (int i = 0; i <= _count-1; i++)
            {
                if (_monthes[i].Equals(item))
                {
                    result = true;
                    _count--;
                    for (int j = i; j <= _count-1; j++)
                    {
                        _monthes[j] = _monthes[j + 1];
                    }
                }
            }

            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i <= _count - 1; i++)
            {
                yield return _monthes[i];
            }
        }
    }
}
