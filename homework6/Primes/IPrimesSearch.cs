using System.Collections.Generic;

namespace Primes
{
    interface IPrimesSearch
    {
        List<int> GetPrimeNumbers(int lowerBound, int upperBound);

        int GetPrimeNumbersAmount(int lowerBound, int upperBound);

        bool IsSimple(int number);
    }
}
