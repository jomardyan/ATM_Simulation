using System;
using System.Linq;

namespace ATM_Simulation
{
    public static class func
    {

        public static bool CardCheck(string CardNumber)
        {
            int sum = 0;
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
                    Console.WriteLine(Digits[i]);

                }
                foreach (int item in Digits)
                {
                    sum = sum + item;
                }
                Console.WriteLine("Sum: " + sum);
            }
            bool x = sum % 10 == 0 ? true : false;
            return x;
        }

        public static void PinCheck()
        {

        }

        public static void Logger()
        {

        }


    }
}
