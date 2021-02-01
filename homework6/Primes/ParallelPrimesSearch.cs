using System.Collections.Generic;
using System.Linq;

namespace Primes
{
    public class ParallelPrimesSearch : PrimesSearch, IPrimesSearch
    {
        public List<int> GetPrimeNumbers(int lowerBound, int upperBound)
        {
            List<int> primeNumbers = new List<int>();

            if (upperBound - lowerBound <= 0)
            {
                return primeNumbers;
            }

            primeNumbers = Enumerable.Range(lowerBound, (upperBound - lowerBound)).AsParallel().Where(x => IsSimple(x)).ToList();
            return primeNumbers;
        }

        public int GetPrimeNumbersAmount(int lowerBound, int upperBound)
            => GetPrimeNumbers(lowerBound, upperBound).Count();
    }
}
