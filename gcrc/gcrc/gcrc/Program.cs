//Huseyn Shahinduran

//Glasgow Clyde Runner Club Project

using System;

namespace gcrc
{
    class Program
    {
        //Global Variables
        static int option = 0; 
        static string search = "";
        static string[] races = { "400m",  "800m", "1500m"};
        static string[] runner = { "Runner 1", "Runner 2", "Runner 3", "Runner 4", "Runner 5", "Runner 6", "Runner 7", "Runner 8" };
        static double[] times = new double[8];
        static double total = 0;
        static double avrg = 0;
        const int quit_option = 5;
        static string username;
        static string login;
        static int count;
        static string password = "clyderunners";

        static void input_details() //Gets user details
        {
            Console.WriteLine("Please enter username: ");
            username = Console.ReadLine();

            Console.WriteLine("Please enter password: ");
            login = Console.ReadLine();
        }

        static void print_message() //test the details and prints a message
        {
            const int quit_option = 4; //local variable

            int choice = 0; //global variable

            if (login == password)
            {
                while (choice != quit_option)
                {
                    Console.WriteLine("Display Menu here");

                    choice = 4;  //for unit test only, take out when you integrate
                }
            }
            else
            {
                count += 1;   //count password attempts

                Console.WriteLine($"Invalid password and username - attempt {count}");
            }

        }

        static void inputTimes() //Get times
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"Enter time for {runner[i]} in {races[0]}: "); //Prompt user to enter times
                times[i] = Convert.ToDouble(Console.ReadLine()); //Get times

                while (times[i] < 0 | times[i] > 40)
                {
                    Console.Write($"Inalid entry. Enter time for {runner[i]} in {races[0]}: "); //Prompt user to enter times
                    times[i] = Convert.ToDouble(Console.ReadLine()); //Get times
                }
            }
        }

        /*Main Menu*/
        public static void display_menu() //Display Menu
        {
            Console.Clear(); //Clear screen

            Console.WriteLine("\t\tGlasgow Clyde Runner");
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\t\t1. Details");
            Console.WriteLine("\t\t2. Times");
            Console.WriteLine("\t\t3. Occurence");
            Console.WriteLine("\t\t4. Search");
            Console.WriteLine("\t\t5. EXIT");
        }

        public static void get_option() //Get user option
        {
            Console.Write("\nEnter your option: "); //Prompt user to enter option
            option = Convert.ToInt32(Console.ReadLine()); //Get option
        }

        public static void act_on_choice()
        {
            switch (option) //switch user option and print
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
                    Console.WriteLine("You have selected Occurence option");
                    Console.WriteLine($"{occurence()} people finished same time.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("You have selected Search option");
                    Search();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Environment.Exit(0); //Exit program
                    break;
            }
        }

        /*Option 1*/
        public static void details() //Print runner details
        {
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{runner[i]} has a race time of {times[i]} seconds in {races[0]}.");
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

        public static void sub_menu() //Display sub menu
        {
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\t\t1. Fastest");
            Console.WriteLine("\t\t2. Slowest");
            Console.WriteLine("\t\t3. Average");
        }

        public static void sub_act_on_choice()
        {
            switch (option) //switch sub option and print
            {
                case 1: //Print fastest time
                    Console.WriteLine($"The fastest is {fastestTime()}");
                    break;
                case 2: //Print slowest time
                    Console.WriteLine($"The slowest is {slowestTime()}");
                    break;
                case 3: //Print average time
                    avrgTimes();
                    break;
            }
        }

        public static double fastestTime() //Calculate fastest time
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

        public static double slowestTime() //Calculate slowest time
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

        public static void avrgTimes() //Calculate the average times
        {
            for (int i = 0; i < 8; i++)
            {
                total += times[i];
            }

            avrg = total / 8;

            Console.WriteLine($"The average is {avrg}");
        }

        /*Option 3*/
        static int occurence() //
        {
            int count = 0; //Local variable

            Console.WriteLine("Enter a time to check occurence: "); //Prompt user to enter occurence
            int number = Convert.ToInt32(Console.ReadLine()); //Get occurence

            for(int i = 0; i < 7; i++)
            {
                if(number == times[i])
                {
                    count += i;
                }
            }

            return count;
        }

        public static void Search()
        {
            Console.WriteLine("Which runner are you looking for?"); //Prompt user to enter which runner are users looking for?
            search = Console.ReadLine(); //Get search

            for(int i = 0; i < 8; i++)
            {
                if(search == runner[i])
                {
                    Console.WriteLine($"{runner[i]} ran {races[0]} meters in {times[i]} seconds."); //Print details
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Clyde Runners");

            while (login != password && count < 3)
            {
                input_details();
                print_message();//loop until password is correct
            }//end while

            if (count == 3)
            {
                Console.WriteLine("Locked out after 3 goes - contact Admin");
            }

            Console.Clear();
            inputTimes();

            while (option != quit_option)
            { 
                print_message();
                display_menu();
                get_option();
                act_on_choice();
            }
        }
    }
}
