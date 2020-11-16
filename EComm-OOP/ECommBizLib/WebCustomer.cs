using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommBizLib
{
    public class WebCustomer : BaseCustomer
    {
        public override decimal CalculateTotal()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total payment calculation in process for Web Customer {this.Name}");
            var total = this._shoppingCart.GetTheTotal() + this._shoppingCart.CalculateTotalTax(10);
            
            Console.ForegroundColor = ConsoleColor.White;

            return total;
        }
    }
}
