using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class CounterService
    {
        private int _count = 0;
        private readonly object _lock = new object();

        // TODO 4: Реализовать безопасный общий счётчик при параллельных задачах.
        public void IncrementSafe()
        {
            lock (_lock)
            {
                _count++;
            }
        }
        //не правилоьный
        public void IncrementUnsafe()
        {
            _count++;
        }

        public int GetCount() => _count;
    }
}
