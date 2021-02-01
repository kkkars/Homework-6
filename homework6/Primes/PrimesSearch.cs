using System.Linq;

namespace Primes
{
    public class PrimesSearch
    {
        public bool IsSimple(int number)
        {
            if (number < 2)
            {
                return false;
            }
            return !Enumerable.Range(2, number).Any(x => x != number && number % x == 0);
        }
    }
}
