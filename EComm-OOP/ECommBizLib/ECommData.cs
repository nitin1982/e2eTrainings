using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommBizLib
{
    public class ECommData
    {
        public static List<Product> GetAllProducts()
        {
            Product p1 = new Product { ProductId = 151, ProductName = "Nestley Cofee", ProductPrice = 10.25m };
            Product p2 = new Product { ProductId = 152, ProductName = "Kinley Water", ProductPrice = 25m };
            Product p3 = new Product { ProductId = 153, ProductName = "Coke Zero Sugar", ProductPrice = 2.25m };
            Product p4 = new Product { ProductId = 154, ProductName = "Pink Salt", ProductPrice = 2.25m };
            Product p5 = new Product { ProductId = 155, ProductName = "London Tea", ProductPrice = 5.50m };

            List<Product> allProductsInStore = new List<Product>();
            allProductsInStore.Add(p1);
            allProductsInStore.Add(p2);
            allProductsInStore.Add(p3);
            allProductsInStore.Add(p4);
            allProductsInStore.Add(p5);

            return allProductsInStore;
        }

        public static void DisplayProductsInStore(List<Product> allProductsInStore)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in allProductsInStore)
            {

                Console.WriteLine($"Product Id: {item.ProductId}, Name: {item.ProductName}, Price: {item.ProductPrice.ToString("c")}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
