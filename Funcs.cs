using System;
using System.Linq;
using System.Text;

namespace ATM_Simulation
{
    public static class Funcs
    {
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
            }
            Log log = new() { Client=client, LogMessage=$"DATE {DateTime.Now} Pin Has been Checked, "};
            db.Add(log);

            db.SaveChanges();
            db.Dispose();
            return check;

        }

        public static void Logger()
        {
        }

        public static void TestDB()

        {
            using var db = new ATMContext();

            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"**Database path**: {db.DbPath}.");

            // Create
            Console.WriteLine("Inserting a new Client");

            db.Add(new Client { Ballance = 156265, ClientName = "Hayk", PIN = 458764545 });
            db.Add(new Transaction { Amount = 300, TransactionDate = DateTime.Now, ClientID = 7 });

            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a Client");
            var client = db.Clients
                .Where(x => x.ClientID == 7)
                .OrderBy(b => b.ClientID)
                .Last();
            var transaction = db.Transactions
                .Where(x => x.Client == client)
                .OrderBy(b => b.TransactionID)
                .Last();

            Console.WriteLine("Client NameL {0},  Client ID: {1}, Client Ballance: {2} ", client.ClientName, client.ClientID, client.Ballance);
            Console.WriteLine("tr ID: " + transaction.TransactionID);
            Console.WriteLine("Client: " + transaction.ClientID);
            Console.WriteLine("Amount: " + transaction.Amount);
            db.Dispose();
        }

        public static void AddClient(Client cl)
        {
            using var db = new ATMContext();
            
            db.Add(cl);
            db.SaveChanges();
            db.Dispose();
        }

        public static void RemoveClient(Client cl)
        {
            using var db = new ATMContext();

            db.Remove(cl);
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
    }
}