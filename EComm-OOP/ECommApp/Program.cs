using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommBizLib;

namespace ECommApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome ABC Ecomm Store!!\nWe have following products in store.\n");

            Thread.Sleep(2000);

            var allProducts = ECommData.GetAllProducts();

            ECommData.DisplayProductsInStore(allProducts);

            /*
             
            WebCustomer webCustomer = new WebCustomer();

            //Must Login First
            webCustomer.LogIn();
            ContinueShopping:
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Enter Product Name and Quantity to Add to Your Cart");
            var itemName = Console.ReadLine();
            var quantity = Console.ReadLine();
            var product = allProducts.FirstOrDefault(x => x.ProductName.ToUpper() == itemName.ToUpper());
            if (product != null)
                webCustomer.AddProductInCart(product, int.Parse(quantity));

            Console.WriteLine("Still shopping? Y/N");

            var response = Console.ReadLine();

            if (response.ToUpper() == "Y")
                goto ContinueShopping;

            webCustomer.CalculateTotal();

            */


            //If Customer is Premium customer, should I repeat above code again??
            //NO

            //ToDo: Use below code

            Console.WriteLine("");
            Console.WriteLine("Enter 'P' for premium customer or enter any other key for web customer");
            var customerType = Console.ReadLine();

            BaseCustomer customer;
            if (customerType.ToUpper() == "P")
            {
                customer = new PremiumCustomer();
                customer.Name = "John Smith";
                customer.Email = "john.smith@gmail.com";
                customer.Id = 1015;
            }
            else
            {
                customer = new WebCustomer();
                customer.Name = "John Smith";
                customer.Email = "john.smith@gmail.com";
                customer.Id = 1015;
            }


            //Must Login First
            customer.LogIn();
        ContinueShopping:
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Enter Product Name and Quantity to Add to Your Cart");
            var itemName = Console.ReadLine();
            var quantity = Console.ReadLine();
            var product = allProducts.FirstOrDefault(x => x.ProductName.ToUpper() == itemName.ToUpper());
            if (product != null)
                customer.AddProductInCart(product, int.Parse(quantity));

            Console.WriteLine("Still shopping? Y/N");

            var response = Console.ReadLine();

            if (response.ToUpper() == "Y")
                goto ContinueShopping;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItems in your cart\n");
            Console.ForegroundColor = ConsoleColor.White;
            customer.ViewAllCartProducts();
            Console.WriteLine("");
            decimal totalToPay = customer.CalculateTotal();

            Console.WriteLine($"You need to pay {totalToPay}");

            customer.MakePayment(totalToPay);

            Thread.Sleep(1500);
            Console.WriteLine("Cheking customer's rewards.\n");

            Thread.Sleep(1500);
            if (customerType.ToUpper() == "P")
            {
                int rewardPoints = (customer as IRewardSystem).GetTheRewardPoints();
                Console.WriteLine($"You have total {rewardPoints} so far.\n\n");
            }
            else
            {
                Console.WriteLine("Web customer is not eligible for reward system");
            }
        }
    }
}
