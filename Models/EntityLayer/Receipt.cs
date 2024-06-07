using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models
{
    public class Receipt : BasePropertyChanged
    {
        private int? receiptID;
        public int? ReceiptID
        {
            get
            {
                return receiptID;
            }
            set
            {
                receiptID = value;
                NotifyPropertyChanged("ReceiptID");
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }
        private float? profit;
        public float? Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit = value;
                NotifyPropertyChanged("Profit");
            }
        }
        private int? userID;
        public int? UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                NotifyPropertyChanged("UserID");
            }
        }
    }
}
