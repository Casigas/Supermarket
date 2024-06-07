using SupermarketMVP.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketMVP.Exceptions;
using System.Windows;

namespace SupermarketMVP.Models.BusinessLogisticLayer
{
    public class CategoryBLL
    {
        public ObservableCollection<Category> CategoryList { get; set; }
        CategoryAccesSQL categorySQL = new CategoryAccesSQL();
        public ObservableCollection<Category> GetAllCategories()
        {
            return categorySQL.GetAllCategories();
        }
        public void AddCategory(Category category)
        {
            if (categorySQL.CategoryExists(category.CategoryName))
            {
                throw new AgendaException("Category already exists!");
            }
            categorySQL.AddCategory(category);
            CategoryList.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new AgendaException("Select a category!");
            }
            if (string.IsNullOrEmpty(category.CategoryName))
            {
                throw new AgendaException("Category name must be specified!");
            }
            categorySQL.UpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new AgendaException("Category name must be specified!");
            }
            else
            {
                ProductAccesSQL productSQL = new ProductAccesSQL();
                int productCount = productSQL.CountProductsInCategory(category.CategoryID.Value);
                if (productCount > 0)
                {
                    throw new AgendaException("In this category still exist products!");
                }
            }
            categorySQL.DeleteCategory(category); 
            CategoryList.Remove(category);
        }
    }
}
