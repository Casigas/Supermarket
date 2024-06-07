using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SupermarketMVP.Models
{
    public class Offer : BasePropertyChanged
    {
        private int? offerID;
        public int? OfferID
        {
            get
            {
                return offerID;
            }
            set
            {
                offerID = value;
                NotifyPropertyChanged("OfferID");
            }
        }
        private string reason;
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                reason = value;
                NotifyPropertyChanged("Reason");
            }
        }
        private int? discount;
        public int? Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                NotifyPropertyChanged("Discount");
            }
        }
        private DateTime start_date;
        public DateTime StartDate
        {
            get
            {
                return start_date;
            }
            set
            {
                start_date = value;
                NotifyPropertyChanged("StartDate");
            }
        }
        private DateTime end_date;
        public DateTime EndDate
        {
            get
            {
                return end_date;
            }
            set
            {
                end_date = value;
                NotifyPropertyChanged("EndDate");
            }
        }

    }
}
