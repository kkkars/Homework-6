using System.Collections.Generic;
using System.Linq;
using Primes;


namespace homework6.Task2
{
    class ThreadSafeList
    {
        private static readonly object Marker = new object();
        private ConsistentPrimesSearch search = new ConsistentPrimesSearch();
        private int count = 0;

        private List<int> primeNumbers = new List<int>();
        private List<Setting> settings = new List<Setting>();

        public ThreadSafeList(List<Setting> settings)
        {
            this.settings = settings;
        }

        public void Add()
        {
            lock (Marker)
            {
                primeNumbers.AddRange(search.GetPrimeNumbers(settings[count].LowerBound, settings[count].UpperBound));
                count++;
            }
        }

        public int[] ToArray()
            => primeNumbers.Distinct().ToArray();
    }
}
