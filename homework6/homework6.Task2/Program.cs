using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace homework6.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var settingService = new SettingService("settings.json");
            var resultService = new ResultService("result.json");
            List<Setting> settings;

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            try
            {
                settings = settingService.GetSettings();
            }
            catch (Exception)
            {
                stopwatch.Stop();
                resultService.WriteResultIntoFile(new Result(false, "The JSON file is missing or corrupted", stopwatch.Elapsed.ToString(), null));
                return;
            }

            var threadSafeList = new ThreadSafeList(settings);
            var threads = new List<Thread>();

            for (int i = 0; i < settings.Count; i++)
            {
                Thread thread = new Thread(threadSafeList.Add);
                thread.Start();
                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            stopwatch.Stop();
            resultService.WriteResultIntoFile(new Result(true, null, stopwatch.Elapsed.ToString(), threadSafeList.ToArray()));
        }
    }
}
