using System.Text.RegularExpressions;
using System.Threading.Channels;
using TeamPizzaTask.Models;
using TeamPizzaTask.Services;

namespace TeamPizzaTask
{
    internal class Program
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<Product> Cart { get; set; } = new List<Product>();
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
                        Console.WriteLine("ef");
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

        static void UserMenu()
        {
            Console.WriteLine("User menyusu:");
            Console.WriteLine("1. Pizzalara bax");
            Console.WriteLine("2. Sifariş ver");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowPizzaMenu();
                    break;
                case 2:
                    PlaceOrder();
                    break;
                default:
                    Console.WriteLine("Düzgün seçim edilməyib.");
                    break;
            }
        }

        static void ShowPizzaMenu()
        {
            Console.WriteLine("Pizza menu:");
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{Products[i].Id}. {Products[i].Name} ");
            }

            Console.WriteLine("Press 'S' to add a pizza to the cart, 'G' to go back to the user menu, or '0' to exit:");
            char key = Console.ReadKey().KeyChar;

            if (key == 'S' || key == 's')
            {
                Console.WriteLine("\nEnter the ID of the pizza to add to cart:");
                int pizzaId = Convert.ToInt32(Console.ReadLine());

                if (pizzaId > 0 && pizzaId <= Products.Count)
                {
                    Cart.Add(new Product
                    {
                        Id = Products[pizzaId - 1].Id,
                        Name = Products[pizzaId - 1].Name,
                        Price = Products[pizzaId - 1].Price,
                        Quantity = 0
                    });

                    Console.WriteLine("Pizza added to cart.");

                    Console.WriteLine("Enter the quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Cart[Cart.Count - 1].Quantity = quantity;

                    Console.WriteLine($"{quantity} pizza(s) added to cart.");

                    Console.WriteLine("Your Cart:");
                    foreach (var item in Cart)
                    {
                        Console.WriteLine($"{item.Id}. {item.Name} Quantity: {item.Quantity} Price: ${item.Price * item.Quantity}");
                    }

                    ShowPizzaMenu();
                }
                else
                {
                    Console.WriteLine("Invalid pizza ID.");
                    ShowPizzaMenu();
                }
            }
            else if (key == 'G' || key == 'g')
            {
                UserMenu();
            }
            else if (key == '0')
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nInvalid key. Please try again.");
                ShowPizzaMenu();
            }
        }



        static void PlaceOrder()
        {
            decimal totalPrice = 0;

            Console.WriteLine("Your Cart:");
            foreach (var item in Cart)
            {
                Console.WriteLine($"{item.Id}. {item.Name} Quantity: {item.Quantity} Price: ${item.Price * item.Quantity}");
                totalPrice += item.Price * item.Quantity;
            }

            Console.WriteLine($"Total Price: ${totalPrice}");

            Console.WriteLine("Enter delivery address:");
            string address = Console.ReadLine();

            string phoneNumber;
            do
            {
                Console.WriteLine("Enter phone number (e.g., +994501234567):");
                phoneNumber = Console.ReadLine();
            } while (!IsValidPhoneNumber(phoneNumber));

            Console.WriteLine($"Order placed! Total Price: ${totalPrice}, Address: {address}, Phone Number: {phoneNumber}");
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+994(50|51|55|70|77)\d{3}\d{2}\d{2}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
    }
}