using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommBizLib
{
    internal class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<CartLineItem>();
        }
        public List<CartLineItem> Items { get; set; }

        public decimal GetTheTotal()
        {
            decimal total = 0.0m;

            foreach (var item in Items)
            {
                total = total + (item.Product.ProductPrice * item.Quantity);
            }

            return total;
        }
        public decimal CalculateTotalTax(decimal tax)
        {
            return GetTheTotal() * (tax / 100);
        }
            
        public void ViewCart()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Quantity} {item.Product.ProductName}");
            }

            Console.WriteLine($"Total Price: {GetTheTotal()}");
            Console.WriteLine($"Plus Tax: {CalculateTotalTax(10)}");
        }

        public void Clear()
        {
            Items.Clear();
        }
    }

    internal class CartLineItem
    {
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Product Product { get; set; }
    }
}
