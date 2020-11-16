using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommBizLib
{
    public abstract class BaseCustomer
    {
        private string name;

        private bool loogedIn;
        internal ShoppingCart _shoppingCart;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public void MakePayment(decimal amount)
        {
            if (loogedIn == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must log in first");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine($"Making payment for ${amount}");

            var total = _shoppingCart.GetTheTotal() + _shoppingCart.CalculateTotalTax(10);
            if (total == amount)
            {
                Console.WriteLine("Payment processing.....");
                System.Threading.Thread.Sleep(1500);
                _shoppingCart.Clear();
                Console.WriteLine("Paid");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogIn()
        {
            loogedIn = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Customer {Name} logged in");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogOut()
        {
            loogedIn = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Customer '{Name}' logged out");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AddProductInCart(Product p, int quantity)
        {
            if (loogedIn == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must log in first");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (_shoppingCart == null)
                _shoppingCart = new ShoppingCart();
            _shoppingCart.Items.Add(new CartLineItem { Product = p, Quantity = quantity });
            Console.WriteLine($"{quantity} '{p.ProductName}' added to your cart");

        }

        public void ViewAllCartProducts()
        {
            if (loogedIn == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must log in first");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (_shoppingCart == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Item in your cart");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            _shoppingCart.ViewCart();
        }
        public abstract decimal CalculateTotal();
    }
}
