using System;

namespace homework6.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unique login service (Task 3) by Bilotska Karyna");
            var menu = new Menu();
            menu.StartMenu();
            Console.WriteLine("Done!\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
