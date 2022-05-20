using System;

namespace ATM_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string card = "5514909496370073";
            Console.WriteLine(card);
            Console.WriteLine("-----------------");
            var x = func.CardCheck(card);
            if (x == true)
            {
                Console.WriteLine("The card is Valid");
            }
            else
            {
                Console.WriteLine("The card is IN-VALID");
            }
        }
    }
}
