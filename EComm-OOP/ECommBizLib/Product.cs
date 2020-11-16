using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommBizLib
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private decimal _productPrice;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public decimal ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }


    }
}
