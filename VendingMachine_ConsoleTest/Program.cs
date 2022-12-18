using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_ConsoleTest
{
    class Program
    {
        static public int amount;
        static public int rest;
        static public bool[] values = new bool[3]; // values[0] - eject product / values[1] - rest nickel/ values[2] - return dime
        static string x;

        static void Main(string[] args)
        {
            Console.WriteLine($"Your amount up until now: 0");
            while (!(values[0]==true) || (amount != 20))
            {
                if(amount < 20)
                { 
                    Console.WriteLine("Please insert a coin!(N,D,Q):");
                    x = Console.ReadLine().ToUpper();
                    if (x != "N" && x != "D" && x != "Q") Console.WriteLine("Please insert one of the coins here N/D/Q!");
                    else
                    {
                        verifyAmount(x);
                        Console.WriteLine($"Your amount up until now: {amount}");
                    }
                }
                else
                    verifyAmount(x);
                if (values[1]) { rest += 5; amount -= 5; values[1] = false; }
                if (values[2]) { rest += 10; amount -= 10; values[2] = false; }
            }
            GiveRest();
            //Console.WriteLine($"Your rest is {rest}");
            Console.WriteLine("Your product has been purchased!");
            amount = 0;
            Console.ReadKey();
        }

        private static void GiveRest()
        {
            switch(rest)
            {
                case 0: Console.WriteLine($"No rest.)"); break;
                case 5: Console.WriteLine($"Your rest is {rest} cents (1 Nickel)"); break;
                case 10: Console.WriteLine($"Your rest is {rest} cents (1 Dime)"); break;
                case 15: Console.WriteLine($"Your rest is {rest} cents (1 Dime and 1 Nickel)"); break;
                case 20: Console.WriteLine($"Your rest is {rest} cents (2 Dimes)"); break;
            }
        }

        private static void verifyAmount(string x)
        {
            switch(amount)
            {
                case 0:
                    StatusA(x);
                    break;
                case 5:
                    StatusB(x);
                    break;
                case 10:
                    StatusC(x);
                    break;
                case 15:
                    StatusD(x);
                    break;
                case 25:
                    values[0] = true;
                    values[1] = true;
                    values[2] = false;
                    break;

            }
           
        }

        private static void StatusD(string x)
        {
            switch (x)
            {
                case "N":
                    values[0] = true;
                    values[1] = false;
                    values[2] = false;
                    amount += 5;
                    break;
                case "D":
                    values[0] = true;
                    values[1] = true;
                    values[2] = false;
                    amount += 10;
                    break;
                case "Q":
                    values[0] = true;
                    values[1] = true;
                    values[2] = true;
                    amount += 25;
                    break;
            }
        }

        private static void StatusC(string x)
        {
            switch (x)
            {
                case "N":
                    values[0] = false;
                    values[1] = false;
                    values[2] = false;
                    amount += 5;
                    break;
                case "D":
                    values[0] = true;
                    values[1] = false;
                    values[2] = false;
                    amount += 10;
                    break;
                case "Q":
                    values[0] = true;
                    values[1] = true;
                    values[2] = true;
                    amount += 25;
                    break;
            }
        }

        private static void StatusB(string x)
        {
            switch (x)
            {
                case "N":
                    values[0] = false;
                    values[1] = false;
                    values[2] = false;
                    amount += 5;
                    break;
                case "D":
                    values[0] = false;
                    values[1] = false;
                    values[2] = false;
                    amount += 10;
                    break;
                case "Q":
                    values[0] = true;
                    values[1] = false;
                    values[2] = true;
                    amount += 25;
                    break;
            }
        }

        private static void StatusA(string x)
        {
            switch (x)
            {
                case "N":
                    values[0] = false;
                    values[1] = false;
                    values[2] = false;
                    amount += 5;
                    break;
                case "D":
                    values[0] = false;
                    values[1] = false;
                    values[2] = false;
                    amount += 10;
                    break;
                case "Q":
                    values[0] = true;
                    values[1] = true;
                    values[2] = false;
                    amount += 25;
                    break;
            }
        }

    }
}
