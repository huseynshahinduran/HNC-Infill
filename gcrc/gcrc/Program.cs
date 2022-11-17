using System;

namespace gcrc
{
    class Program
    {
        static int option = 0;
        static string search = "";
        static string[] races = { "400m",  "800m", "1500m"};
        static string[] runner = { "Runner 1", "Runner 2", "Runner 3", "Runner 4", "Runner 5", "Runner 6", "Runner 7", "Runner 8" };
        static double[] times = new double[8];
        static double total = 0;
        static double avrg = 0;
        const int quit_option = 4;
        static bool ok = false;

        static void Main(string[] args)
        {
            inputLoop();

            while (option != quit_option)
            {
                display_menu();
                get_option();
                act_on_choice();
            }
        }

        static void inputTimes()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"Enter time for {runner[i]} in {races[0]}: ");
                times[i] = Convert.ToDouble(Console.ReadLine());

                if(times[i] >= 0 & times[i] <= 40)
                {
                    while(times[i] < 0 | times[i] > 40)
                    {
                        Console.Write($"Enter time for {runner[i]} in {races[0]}: ");
                        times[i] = Convert.ToDouble(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid details");
                }
            }
        }

        static void inputLoop()
        {
            for (int i = 1; i <= 3; i++)//For loop
            {
                inputTimes();
                if (ok == true)
                {
                    break;
                }
                else if (i == 3)
                {
                    Console.WriteLine("System locked out"); 
                }
            }
        }

        /*Main Menu*/
        public static void display_menu()
        {
            Console.Clear();

            Console.WriteLine("\t\tGlasgow Clyde Runner");
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\t\t1. Details");
            Console.WriteLine("\t\t2. Times");
            Console.WriteLine("\t\t3. Search");
            Console.WriteLine("\t\t4. EXIT");
        }

        public static void get_option()
        {
            Console.Write("\nEnter your option: ");
            option = Convert.ToInt32(Console.ReadLine());
        }

        public static void act_on_choice()
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("You have selected Details option");
                    details();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("You have selected Times option");
                    race_time();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("You have selected Search option");
                    Console.WriteLine($"{occurence()} people finished same time.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        /*Option 1*/
        public static void details()
        {
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{runner[i]} has a race time of {times[i]} seconds in {races}.");
            }
        }

        /*Option 2*/
        static void race_time()
        {
            Console.Clear();

            sub_menu();
            get_option();
            sub_act_on_choice();
        }

        public static void sub_menu()
        {
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\t\t1. Fastest");
            Console.WriteLine("\t\t2. Slowest");
            Console.WriteLine("\t\t3. Average");
        }

        public static void sub_act_on_choice()
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine($"The fastest is {fastestTime()}");
                    break;
                case 2:
                    Console.WriteLine($"The slowest is {slowestTime()}");
                    break;
                case 3:
                    avrgTimes();
                    break;
            }
        }

        public static double fastestTime()
        {
            double max = times[0];

            for (int i = 0; i < 8; i++)
            {
                if (times[i] > max)
                {
                    max = times[i];

                }
            }
            return max;
        }

        public static double slowestTime()
        {
            double min = times[0];

            for (int i = 0; i < 8; i++)
            {
                if (times[i] < min)
                {
                    min = times[i];

                }
            }
            return min;
        }

        public static void avrgTimes()
        {
            for (int i = 0; i < 8; i++)
            {
                total += times[i];
            }

            avrg = total / 8;

            Console.WriteLine($"The average is {avrg}");
        }

        /*Option 3*/
        static int occurence()
        {
            int count = 0;

            Console.WriteLine("Enter a time to check occurence: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < 7; i++)
            {
                if(number == times[i])
                {
                    count += i;
                }
            }

            return count;
        }

        /*public static void Search()
        {
            Console.WriteLine("What runner are you looking for?");
            search = Console.ReadLine();

            for(int i = 0; i < 8; i++)
            {
                if(search == runner[i])
                {
                    Console.WriteLine($"{runner[i]} ran {races[0]} meters in {times[i]} seconds.");
                }
            }
        }*/


    }
}
