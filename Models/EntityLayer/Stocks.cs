using SupermarketMVP.Models.EntityLayer;
using System;

namespace SupermarketMVP.Models
{
    public class Stocks : BasePropertyChanged
    {
        private int? productID;
        public int? ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
                NotifyPropertyChanged("ProductID");
            }
        }

        private Product product;
        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                NotifyPropertyChanged("Product");
            }
        }

        private int? amount;
        public int? Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        private string unit;
        public string UnitName
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                NotifyPropertyChanged("UnitName");
            }
        }

        private DateTime expiration_date;
        public DateTime ExpirationDate
        {
            get
            {
                return expiration_date;
            }
            set
            {
                expiration_date = value;
                NotifyPropertyChanged("ExpirationDate");
            }
        }

        private DateTime supply_date;
        public DateTime SupplyDate
        {
            get
            {
                return supply_date;
            }
            set
            {
                supply_date = value;
                NotifyPropertyChanged("SupplyDate");
            }
        }

        private float? purchasePrice;
        public float? PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
                NotifyPropertyChanged("PurchasePrice");
            }
        }

        private float? sellPrice;
        public float? SellPrice
        {
            get
            {
                return sellPrice;
            }
            set
            {
                sellPrice = value;
                NotifyPropertyChanged("SellPrice");
            }
        }
    }
}
