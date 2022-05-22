using EasyConsoleCore;
using System;

namespace ATM_Simulation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome GTX ATM Terminal!");
            string input = Input.ReadString("Please enter a card number:");



            var a = BankOperations.CardCheck(input);

            while (a==false)
            {
                try
                {
                    string input2 = Input.ReadString("Please enter a valid card number:");
                    a = BankOperations.CardCheck(input2);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.ReadLine();
        }
    }
}
