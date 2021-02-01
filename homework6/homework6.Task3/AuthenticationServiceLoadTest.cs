using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace homework6.Task3
{
    public static class AuthenticationServiceLoadTest
    {
        private static CountdownEvent Countdown;
        static int successTriesAmount = 0;
        static int failedTriesAmount = 0;
        static ConcurrentQueue<LogInData> loginData = new ConcurrentQueue<LogInData>();

        public static void StartLogInTest(int threadAmount)
        {
            Countdown = new CountdownEvent(threadAmount);

            var threads = new List<Thread>(threadAmount);
            for (int i = 0; i < threadAmount; i++)
            {
                Thread thread = new Thread(() =>
                {
                    var loginClient = new LoginClient();
                    while (loginData.TryDequeue(out LogInData pair))
                    {
                        var token = loginClient.LogIn(pair.Login, pair.Password);
                        if (token != null)
                        {
                            Interlocked.Increment(ref successTriesAmount);
                        }
                        else
                        {
                            Interlocked.Increment(ref failedTriesAmount);
                        }
                    }
                    Countdown.Signal();
                });
                thread.Start();
                threads.Add(thread);
            }

            Countdown.Wait();
        }

        public static void SetDataToQuene(List<LogInData> data)
        {
            foreach (LogInData logData in data)
            {
                loginData.Enqueue(logData);
            }
        }

        public static Result GetFinalResult()
            => new Result(successTriesAmount, failedTriesAmount);
    }
}
