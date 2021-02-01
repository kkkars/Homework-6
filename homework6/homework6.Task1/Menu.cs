using System;
using System.Diagnostics;
using Primes;

namespace homework6.Task1
{
    public static class Menu
    {
        public static void StartMenu()
        {
            Stopwatch stopwatch = new Stopwatch();
            int lowerBound, upperBound;

            while (true)
            {
                Console.WriteLine("Set range:");
                lowerBound = GetLowerBound();
                upperBound = GetUpperBound();
                if (lowerBound <= upperBound)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lower bound can't be bigger than upper bound. Please, enter range again\n");
                }
            }

            while (true)
            {
                Console.WriteLine("\nChoose how to search:");
                ShowMenu();
                string option = GetOption();
                if (option == "1")
                {
                    ConsistentPrimesSearch search = new ConsistentPrimesSearch();
                    stopwatch.Start();
                    Console.WriteLine($"\nPrimes amount: {search.GetPrimeNumbersAmount(lowerBound, upperBound)}");
                    stopwatch.Stop();
                    Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
                    return;
                }
                else
                if (option == "2")
                {
                    ParallelPrimesSearch search = new ParallelPrimesSearch();
                    stopwatch.Start();
                    Console.WriteLine($"\nPrimes amount: {search.GetPrimeNumbersAmount(lowerBound, upperBound)}");
                    stopwatch.Stop();
                    Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong option. Please, try again\n");
                }
            }
        }

        private static string GetOption()
        {
            Console.Write("Option: ");
            return Console.ReadLine().Trim();
        }

        private static int GetLowerBound()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the lower bound: ");
                    return Convert.ToInt32(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered wrong format. Try again.\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The entered number is too big. Please, enter an integer.\n");
                }
            }
        }

        private static int GetUpperBound()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the upper bound: ");
                    return Convert.ToInt32(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered wrong value. Try again.\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The entered number is too big. Please, enter an integer.\n");
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("1.Search primes with LINQ\n2.Search primes with PLINQ\n");
        }
    }
}
