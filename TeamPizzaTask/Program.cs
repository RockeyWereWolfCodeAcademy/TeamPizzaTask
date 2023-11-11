using System.Text.RegularExpressions;
using System.Threading.Channels;
using TeamPizzaTask.Models;
using TeamPizzaTask.Services;

namespace TeamPizzaTask
{
    internal class Program
    {
        public static User CurrentUser;

        static void Main(string[] args)
        {
            // Pizza samples 
            ProductService.AddProduct("Pizza Margherita", 20);
            ProductService.AddProduct("Pepperoni Pizza", 10);
            ProductService.AddProduct("Vegetarian Pizza", 30);

            UserService.AddUser("admin", "admin", "admin", "admin", true); // Default admin yaradilir
            while (true)
            {
                Console.WriteLine("Choose from options:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registration");
                Console.WriteLine("0. Exit from system\n");

                char choice = Console.ReadKey(intercept: true).KeyChar;

                switch (choice)
                {
                    case '1':
                        //implemented login method
                        UserService.Login();
                        break;
                    case '2':
                        //implemented register method
                        UserService.Register();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again...\n");
                        break;
                }
            }
        }

        public static void UserMenu()
        {

            Console.WriteLine("User menu:");
            Console.WriteLine("1. Show pizza menu");
            Console.WriteLine("2. Place your order");
            Console.WriteLine("0. Log out\n");
            
            char choice = Console.ReadKey(intercept: true).KeyChar;

            while (choice != '0')
            {
                switch (choice)
                {
                    case '1':
                        ShowPizzaMenu();
                        break;
                    case '2':
                        PlaceOrder();
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Invalid option!\n");
                        break;

                } 
            }
        }

        static void ShowPizzaMenu()
        {
            Console.WriteLine("Pizza menu:");
            ProductService.GetProducts().ForEach(product => Console.WriteLine($"{product.Id}. {product.Name} Price: {product.Price} "));
            Console.Write("\nEnter ID of pizza to add to your cart: ");
            uint buyId = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("\nPress 'S' to add a pizza to the cart, 'G' to return to Pizza Menu , or '0' to go back to the user menu:\n");
            char key = Console.ReadKey(intercept: true).KeyChar;

            if (key == 'S' || key == 's')
            {
                if (buyId > 0 && buyId <= ProductService.GetProducts().Count)
                {
                    CurrentUser.Cart.Add(new Product
                    {
                        Id = ProductService.GetProductById(buyId).Id,
                        Name = ProductService.GetProductById(buyId).Name,
                        Price = ProductService.GetProductById(buyId).Price,
                        Quantity = 0
                    });

                    Console.WriteLine("Pizza added to cart.\n");

                    Console.Write("Enter the quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    CurrentUser.Cart[CurrentUser.Cart.Count - 1].Quantity = quantity;

                    Console.WriteLine($"{quantity} pizza(s) added to cart.\n");

                    Console.WriteLine("Your Cart:");
                    CurrentUser.Cart.ForEach(cart => Console.WriteLine($"{cart.Id}. {cart.Name} Quantity: {cart.Quantity} Price: ${cart.Price * cart.Quantity}"));

                    ShowPizzaMenu();
                }
                else
                {
                    Console.WriteLine("Invalid pizza ID.\n");
                    ShowPizzaMenu();
                }
            }
            else if (key == 'G' || key == 'g')
            {
                ShowPizzaMenu();
            }
            else if (key == '0')
            {
                UserMenu(); 
            }
            else
            {
                Console.WriteLine("\nInvalid key. Please try again.");
                //ShowPizzaMenu();
            }
        }



        static void PlaceOrder()
        {
            decimal totalPrice = 0;

            Console.WriteLine("Your Cart:");
            foreach (var item in CurrentUser.Cart)
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