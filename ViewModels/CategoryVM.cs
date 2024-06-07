//using SupermarketMVP.Models;
//using SupermarketMVP.Models.BusinessLogisticLayer;
//using SupermarketMVP.Models.EntityLayer;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace SupermarketMVP.ViewModels
//{
//    public class CategoryVM : BasePropertyChanged
//    {
//        CategoryBLL categoryBLL = new CategoryBLL();
//        public CategoryVM()
//        {
//            CategoryList = categoryBLL.GetAllCategories();
//        }

//        #region Data Members

//        public ObservableCollection<Category> CategoryList
//        {
//            get => categoryBLL.CategoryList;
//            set => categoryBLL.CategoryList = value;
//        }

//        #endregion

//        #region Command Members

//        private ICommand addCommand;
//        public ICommand AddCommand
//        {
//            get
//            {
//                if (addCommand == null)
//                {
//                    addCommand = new RelayCommand<Category>(categoryBLL.AddCategory);
//                }
//                return addCommand;
//            }
//        }

//        private ICommand updateCommand;
//        public ICommand UpdateCommand
//        {
//            get
//            {
//                if (updateCommand == null)
//                {
//                    updateCommand = new RelayCommand<Category>(categoryBLL.UpdateCategory);
//                }
//                return updateCommand;
//            }
//        }

//        private ICommand deleteCommand;
//        public ICommand DeleteCommand
//        {
//            get
//            {
//                if (deleteCommand == null)
//                {
//                    deleteCommand = new RelayCommand<Category>(categoryBLL.DeleteCategory);
//                }
//                return deleteCommand;
//            }
//        }
//        #endregion
//    }
//}


using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class CategoryVM : BasePropertyChanged
    {
        private CategoryBLL categoryBLL = new CategoryBLL();
        private string categoryName;

        public CategoryVM()
        {
            CategoryList = categoryBLL.GetAllCategories();
            NewCategory = new Category();
        }

        #region Data Members

        public ObservableCollection<Category> CategoryList
        {
            get => categoryBLL.CategoryList;
            set
            {
                categoryBLL.CategoryList = value;
                NotifyPropertyChanged(nameof(CategoryList));
            }
        }

        public string CategoryName
        {
            get => categoryName;
            set
            {
                categoryName = value;
                NotifyPropertyChanged(nameof(CategoryName));
            }
        }

        public Category NewCategory { get; set; }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<object>(_ =>
                    {
                        var category = new Category { CategoryName = CategoryName };
                        categoryBLL.AddCategory(category);
                        CategoryName = string.Empty; // Clear the input after adding
                    });
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Category>(categoryBLL.UpdateCategory);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Category>(categoryBLL.DeleteCategory);
                }
                return deleteCommand;
            }
        }

        #endregion
    }
}

