using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    internal class MathService
    {
        // TODO 1: Разделить приложение на сервисы и найти/исправить дефект стартового legacy-кода.
        public int SafeDivide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка: Деление на ноль!");
                return 0;
            }
            return a / b;
        }
    }
}
