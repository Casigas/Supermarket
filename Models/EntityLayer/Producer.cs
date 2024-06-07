using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models
{
    public class Producer : BasePropertyChanged
    {
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
        private string name;
        public string ProducerName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("ProducerName");
            }
        }
        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                NotifyPropertyChanged("Country");
            }
        }
    }
}
