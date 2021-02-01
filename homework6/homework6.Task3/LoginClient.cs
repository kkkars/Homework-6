using System;
using System.Threading;

namespace homework6.Task3
{
    class LoginClient
    {
        public string LogIn(string login, string password)
        {
            var rnd = new Random();
            var chance = rnd.NextDouble();

            var loginTime = rnd.Next(0, 1000);
            Thread.Sleep(loginTime);

            return chance >= 0 && chance <= 0.5 ? Guid.NewGuid().ToString() : null;
        }
    }
}
