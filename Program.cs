using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assisgnment_21
{
    internal class Program
    {
       static List<string> Fruits = new List<string>()
            {
                "Mango","Banana","Grapes","WaterMelon","Melon","Kiwi","Guava","Cherry","Strawberry","Berry"
            };
       static List<string> Days = new List<string>()
            {
                "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
            };
       static List<string> Months = new List<string>()
            {
                "Jan","Feb","Mar","Apr","May","June","July","Aug","Sept","Oct","Nov","Dec"
            };
        static Dictionary<string, string> WordsMeaning = new Dictionary<string, string>()
            {
                {"Absence", "The lack or unavailability of something or someone." },
                {"Approval","Having a positive opinion of something or someone" },
                {"Amount","A mass or a collection of something  " },
                {"Care","extra responsibility and attention"},
                {"Chip"," a small and thin piece of a larger item." }
            };
        static void DisplayDays()
        {
            foreach (string day in Days)
            {
                Console.WriteLine(day);
                Thread.Sleep(14000); // Wait for 14 seconds
            }
        }

        static void DisplayMonths()
        {
            Thread.Sleep(5000); // Wait for 5 seconds before starting
            foreach (string month in Months)
            {
                Console.WriteLine(month);
                Thread.Sleep(2000); // Wait for 2 seconds before displaying the next month
            }
        }

        static void DisplayFruits()
        {
            foreach (string fruit in Fruits)
            {
                Console.WriteLine(fruit);
            }
        }

        static void DisplayWordsAndMeanings()
        {
            foreach (var pair in WordsMeaning)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------Welcome to Learning---------------------------\n");

            // Create threads for each function
            Thread daysThread = new Thread(DisplayDays);
            Thread monthsThread = new Thread(DisplayMonths);
            Thread fruitsThread = new Thread(DisplayFruits);
            Thread wordsThread = new Thread(DisplayWordsAndMeanings);

            // Start the threads
            daysThread.Start();
            monthsThread.Start();

            // Join the days and months threads so that fruits and words start after both of them have finished
            daysThread.Join();
            monthsThread.Join();

            // Start the fruits and words threads
            fruitsThread.Start();
            wordsThread.Start();

            // Join the fruits and words threads so that the program waits for them to finish before exiting
            fruitsThread.Join();
            wordsThread.Join();
            Console.ReadKey();
        }
    }
}

