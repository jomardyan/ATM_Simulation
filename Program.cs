using System;

namespace ATM_Simulation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome GTX ATM Terminal!");

            var menu = new EasyConsoleCore.Menu()
                .Add("Cash WithDrawal", () => Console.WriteLine("foo selected"))
                .Add("Deposit", () => Console.WriteLine("bar selected"))
                .Add("PIN Change", ()=>Console.WriteLine("Pin Change"));
            menu.Display();

            Console.ReadLine();
        }
    }
}