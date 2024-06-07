using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models
{
    public class Product : BasePropertyChanged
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
        private string name;
        public string ProductName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("ProductName");
            }
        }
        private string barCode;
        public string BarCode
        {
            get
            {
                return barCode;
            }
            set
            {
                barCode = value;
                NotifyPropertyChanged("BarCode");
            }
        }
        private int? categoryID;
        public int? CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
                NotifyPropertyChanged("CategoryID");
            }
        }
        private int? producerID;
        public int? ProducerID
        {
            get
            {
                return producerID;
            }
            set
            {
                producerID = value;
                NotifyPropertyChanged("ProducerID");
            }
        }
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
        private Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }

        private Producer producer;
        public Producer Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
                NotifyPropertyChanged("Producer");
            }
        }

        private Offer offer;
        public Offer Offer
        {
            get
            {
                return offer;
            }
            set
            {
                offer = value;
                NotifyPropertyChanged("Offer");
            }
        }
    }
}
