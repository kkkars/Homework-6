using System;
using System.Collections.Generic;

namespace homework6.Task3
{
    class Menu
    {
        public void StartMenu()
        {
            var logDataService = new LogInDataService("data.json");
            List<LogInData> logData;

            try
            {
                logData = logDataService.GetLogData();
            }
            catch
            {
                Console.WriteLine("The json file is missing or corrupted");
                return;
            }

            AuthenticationServiceLoadTest.SetDataToQuene(logData);

            int threadAmount = GetThreadAmount();

            AuthenticationServiceLoadTest.StartLogInTest(threadAmount);

            var resultService = new ResultService("result.json");
            resultService.WriteResultIntoFile(AuthenticationServiceLoadTest.GetFinalResult());
        }

        private static int GetThreadAmount()
        {
            while (true)
            {
                Console.Write("Enter the amount of threads: ");
                try
                {
                    int amount = Convert.ToInt32(Console.ReadLine().Trim());
                    if (amount > 0)
                    {
                        return amount;
                    }
                    else
                    {
                        Console.WriteLine("Wrong amount: amount must be a positive number. Try again.\n ");
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong format: please, enter the digit.\n");
                }
            }
        }
    }
}
