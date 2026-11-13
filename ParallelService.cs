using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class ParallelService
    {
        // TODO 5: Обработать коллекцию параллельно и сравнить результат с LINQ.
        public void CompareProcessing()
        {
            var numbers = Enumerable.Range(1, 100000).ToList();

            var swLinq = System.Diagnostics.Stopwatch.StartNew();
            var linqResult = numbers.Where(x => x % 2 == 0).Select(x => x * x).ToList();
            swLinq.Stop();

            var swPlinq = System.Diagnostics.Stopwatch.StartNew();
            var plinqResult = numbers.AsParallel().Where(x => x % 2 == 0).Select(x => x * x).ToList();
            swPlinq.Stop();

            Console.WriteLine($"LINQ: {swLinq.ElapsedMilliseconds} мс, элементов: {linqResult.Count}");
            Console.WriteLine($"PLINQ: {swPlinq.ElapsedMilliseconds} мс, элементов: {plinqResult.Count}");
        }
    }
}
