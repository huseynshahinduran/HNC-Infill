using System;

namespace bankATM
{
    class Program
    {
        static bool ok = false;

        static void inputDetail(ref string password)
        {
            Console.WriteLine("Please enter password:");
            password = Console.ReadLine();
        }

        static void validateDetail(string password, int select, double balance)
        {
            if (password == "pass")
            {
                menu(select, balance);
                ok = true;
            }
            else
            {
                Console.WriteLine("Wrong Password");
            }
        }

        static void menu(int select, double balance)
        {
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposite");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Log out");
            select = Convert.ToInt32(Console.ReadLine());

            switch (select)
            {
                case 1:
                    Console.WriteLine("*****WITHDRAW*****");
                    break;
                case 2:
                    Console.WriteLine("*****DEPOSIT*****");
                    break;
                case 3:
                    Console.WriteLine("*****CHECK BALANCE******");
                    break;
                case 4:
                    Console.WriteLine("*****LOG OUT*****");
                    break;
            }
        }

        static void loop(string password, int select, double balance)
        {
            for(int i=1; i<=3; i++)
            {
                inputDetail(ref password);
                validateDetail(password, select, balance);
                 
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
            double balance = 1000;

            loop(password, select, balance);
        }
    }
}
