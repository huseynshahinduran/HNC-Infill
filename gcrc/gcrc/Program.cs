using System;

namespace gcrc
{
    class Program
    {
        static string[] name = new string[10];
        static int option = 0;
        static string search = "";
        static string[] races = { "400m",  "800m", "1500m"};
        static double[] times = new double[3];

        static void runner_details()
        {

        }

        static void search_runner()
        {

        }

        static void Main(string[] args)
        {
            display_menu();
            get_option();
            act_on_choice();
        }

        /*Main Menu*/
        public static void display_menu()
        {
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
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        /*Option 2*/
        public static void sub_menu()
        {
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\t\t1. Fastest");
            Console.WriteLine("\t\t2. Slowest");
            Console.WriteLine("\t\t3. Average");
        }

        static void race_time()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter times for {races[i]}: ");
                times[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Clear();

            sub_menu();
            get_option();
            sub_act_on_choice();
        }

        public static void sub_act_on_choice()
        {
            double max = times[0];
            double min = times[0];
            double average = 0;

            switch (option)
            {
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        if (times[i] > max)
                        {
                            max = times[i];
                            Console.WriteLine($"Your fastest rase is {races[i]} meter in {max} seconds.");
                        }

                    }
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        if (times[i] < min)
                        {
                            min = times[i];
                            Console.WriteLine($"Your fastest rase is {races[i]} meter in {min} seconds.");
                        }

                    }
                    break;
                case 3:
                    
                    break;
            }
        }

    }
}
