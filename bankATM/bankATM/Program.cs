using System;

namespace bankATM
{
    class Program
    {
        static bool ok = false;

        static void inputDetail(ref string password)
        {
            Console.WriteLine("Enter Your 4 Digit Pin:");
            password = Console.ReadLine();
        }

        static void validateDetail(string password, int select, int balance, int amount, int lastBalance)
        {
            if (password == "5842")
            {
                menu(select, balance, amount, lastBalance);
                ok = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong Password\n\n");
            }
        }

        static void menu(int select, int balance, int amount, int lastBalance)
        {
            Console.Clear();

            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposite");
            Console.WriteLine("3. Current Balance");
            Console.WriteLine("4. Cancle");
            select = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (select)
            {
                case 1:
                    Console.WriteLine("*****WITHDRAW*****\n");
                    Console.Write("Enter the withdraw amount: ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    lastBalance = balance - amount;
                    Console.WriteLine($"Current balance: £{lastBalance}");

                    Console.WriteLine("\n1. Return Back");
                    Console.WriteLine("2. Cancle");
                    select = Convert.ToInt32(Console.ReadLine());

                    if (select == 1)
                    {
                        menu(select, balance, amount, lastBalance);
                    }
                    else if (select == 2)
                    {
                        break;
                    }
                    break;
                case 2:
                    Console.WriteLine("*****DEPOSIT*****\n");
                    Console.Write("Enter the deposit amount: ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Your amount has benn deposited successfully");
                    lastBalance = balance + amount;
                    Console.WriteLine($"Current balance: £{lastBalance}");

                    Console.WriteLine("\n1. Return Back");
                    Console.WriteLine("2. Cancle");
                    select = Convert.ToInt32(Console.ReadLine());

                    if (select == 1)
                    {
                        menu(select, balance, amount, lastBalance);
                    }
                    else if (select == 2)
                    {
                        break;
                    }
                    break;
                case 3:
                    Console.WriteLine("*****CURRENT BALANCE******\n");
                    Console.WriteLine($"Your current balance is £{balance}"); 

                    Console.WriteLine("\n1. Return Back");
                    Console.WriteLine("2. Cancle");
                    select = Convert.ToInt32(Console.ReadLine());

                    if (select == 1)
                    {
                        menu(select, balance, amount, lastBalance);
                    }
                    else if (select == 2)
                    {
                        break;
                    }
                    break;
                case 4:
                    break;
            }
        }

        static void loop(string password, int select, int balance, int amount, int lastBalance)
        {
            for(int i=1; i<=3; i++)
            {
                inputDetail(ref password);
                validateDetail(password, select, balance, amount, lastBalance);
                 
                if(ok == true)
                {
                    break;
                }
                else if(i == 3)
                {
                    Console.WriteLine("System Out");
                }
            }
        }

        static void Main(string[] args)
        {
            string password = "";
            int select = 0;
            int balance = 1000;
            int amount = 0;
            int lastBalance = 0;

            loop(password, select, balance, amount, lastBalance);
        }
    }
}
