using System.Threading.Channels;
using TeamPizzaTask.Models;
using TeamPizzaTask.Services;

namespace TeamPizzaTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose from options:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registration");
                Console.WriteLine("0. Exit from system");

                char choice = Console.ReadKey(intercept: true).KeyChar;

                switch (choice)
                {
                    case '1':
                        //implemented login method
                        break;
                    case '2':
                        //implemented register method
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again...");
                        break;
                }
            }
        }
    }
}