using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;

namespace SupermarketMVP.ViewModels
{
    public class CategoryAndProductsVM
    {
        public Dictionary<Category, ObservableCollection<Product>> Agenda { get; set; }

        public CategoryAndProductsVM()
        {
            CategoryBLL categoryBLL = new CategoryBLL();
            Agenda = new Dictionary<Category, ObservableCollection<Product>>();
            foreach (Category category in categoryBLL.GetAllCategories())
            { 
                ProductBLL productBLL = new ProductBLL();
                productBLL.GetProductsForCategory(category);
                Agenda.Add(category, productBLL.ProductList);
            }
        }
    }
}
