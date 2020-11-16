using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommBizLib
{
    public enum MemeberShipType
    {
        Executive,
        Gold
    }
    public class PremiumCustomer : BaseCustomer, IRewardSystem
    {
        private int _memberShipId;
        private DateTime _startDate;
        private DateTime _endDate;
        private MemeberShipType _memeberShipType;

        public int MemeberShipId
        {
            get { return _memberShipId; }
            set { _memberShipId = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public MemeberShipType MemeberShipType
        {
            get { return _memeberShipType; }
            set { _memeberShipType = value; }
        }

        public override decimal CalculateTotal()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total payment calculation in process for Premium Customer {this.Name}");
            var total = this._shoppingCart.GetTheTotal() + this._shoppingCart.CalculateTotalTax(20);

            Console.ForegroundColor = ConsoleColor.White;

            return total;
        }

        public int GetTheRewardPoints()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Fetching Rewards info for Premium Customer {this.Name}");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;

            return 3500;
        }
    }
}
