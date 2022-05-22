using EasyConsoleCore;
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
            CardNumber = CardNumber.Replace("-", "").Replace(" ", "");
            

            int sum = 0;
            bool x;
            StringBuilder st = new StringBuilder();
            if (CardNumber.Length > 16 | CardNumber.Length < 16)
            {
                Output.WriteLine(ConsoleColor.Red, "Card number lenght must consist 16 character, please try again");
                return false;
            }
            else
            {
                char[] CardArray = CardNumber.ToArray();
                var Digits = new int[16];
                for (int i = 0; i < CardArray.Length; i++)
                {
                    Digits[i] = Convert.ToInt32(CardArray[i]) - '0';
                    if (Digits[i] > 9)
                    {
                        return false;
                    }
                    
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
                x = sum % 10 == 0 ? true : false;
                if (x == true)
                {
                    using var db = new ATMContext();

                    var card = db.CreditCards
                    .Where(x => x.CardNumber == CardNumber)
                    .OrderBy(b => b.ClientID)
                    .FirstOrDefault();

                   
                    Output.WriteLine(ConsoleColor.Green, "Coreect card!");
                    Output.WriteLine("You Entered: {0}", CardNumber);
                    //Output.WriteLine("Checking PIN..");
                    var cb = PinCheck(Input.ReadInt("Enter PIN: ", 1000, 999999), CardNumber);
                }
            }

            return x;
        }

        public static void Logger(int cl, string logMesage)
        {
            using var db = new ATMContext();

            Log log = new() { ClientID = cl, LogMessage = logMesage };

            db.Add(log);
            db.SaveChanges();
            db.Dispose();
        }

        public static bool PinCheck(int pin, string cardNumber)
        {
            bool check = false;
            using var db = new ATMContext();
            var card = db.CreditCards
                .Where(x => x.CardNumber == cardNumber)
                .OrderBy(b => b.ClientID)
                .FirstOrDefault();

            var client = db.Clients
                .Where(x => x.ClientID == card.ClientID)
                .OrderBy(b => b.ClientID)
                .FirstOrDefault();

            if (client.PIN == pin)
            {
                check = true;
                Logger(client.ClientID, $"DATE {DateTime.Now} Pin Has been provided correctly.");
            }
            else
            {
                Output.WriteLine(ConsoleColor.Red, "WRONG PIN!");
                Logger(client.ClientID, $"DATE {DateTime.Now} Pin Has been provided incorectly.");
            }
            

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