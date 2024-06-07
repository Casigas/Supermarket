using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models
{
    public class User : BasePropertyChanged
    {
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
        private string name;
        public string UserName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("UserName");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }
    }
}
