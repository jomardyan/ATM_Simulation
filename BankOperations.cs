using System;
using System.Linq;
using System.Text;

namespace ATM_Simulation
{
    internal static class BankOperations
    {
        public static void AddClient(Client cl)
        {
            using var db = new ATMContext();

            db.Add(cl);
            db.SaveChanges();
            db.Dispose();
        }

        public static void AddTransaction(Transaction tr)
        {
            using var db = new ATMContext();
            db.Add(tr);
            db.SaveChanges();
            db.Dispose();
        }

        public static bool CardCheck(string CardNumber)
        {
            int sum = 0;
            StringBuilder st = new StringBuilder();

            if (CardNumber.Length == 16)
            {
                char[] CardArray = CardNumber.ToArray();
                var Digits = new int[16];
                for (int i = 0; i < CardArray.Length; i++)
                {
                    Digits[i] = Convert.ToInt32(CardArray[i]) - '0';
                    //Console.WriteLine(CardNumber[i]);
                }

                for (int i = 0; i < Digits.Length; i += 2)
                {
                    if (Digits[i] * 2 > 9)
                    {
                        Digits[i] = ((Digits[i] * 2) % 10) + 1;
                    }
                    else
                    {
                        Digits[i] = Digits[i] * 2;
                    }
                    st.Append(Digits[i]);
                }
                foreach (int item in Digits)
                {
                    sum = sum + item;
                }
                System.Console.WriteLine(st);
                Console.WriteLine("Sum: " + sum);
            }
            bool x = sum % 10 == 0 ? true : false;
            return x;
        }

        public static void Logger(Client cl, string logMesage)
        {
            using var db = new ATMContext();

            Log log = new() { Client = cl, ClientID = cl.ClientID, LogMessage = logMesage };

            db.Add(cl);
            db.SaveChanges();
            db.Dispose();
        }

        public static bool PinCheck(int pin, int clientID)
        {
            bool check = false;
            using var db = new ATMContext();
            var client = db.Clients
                .Where(x => x.ClientID == clientID)
                .OrderBy(b => b.ClientID)
                .FirstOrDefault();

            if (client.PIN == pin)
            {
                check = true;
                Logger(client, $"DATE {DateTime.Now} Pin Has been provided correctly.");
            }
            Logger(client, $"DATE {DateTime.Now} Pin Has been provided incorectly.");

            db.Dispose();
            return check;
        }

        public static void RemoveClient(Client cl)
        {
            using var db = new ATMContext();

            db.Remove(cl);
            db.SaveChanges();
            db.Dispose();
        }
    }
}