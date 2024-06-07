﻿using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models
{
    public class Category : BasePropertyChanged
    {
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
        private string name;
        public string CategoryName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("CategoryName");
            }
        }
    }
}
