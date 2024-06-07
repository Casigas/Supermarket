using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class StocksVM : BasePropertyChanged
    {
        private readonly StocksBLL stocksBLL = new StocksBLL();

        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Stocks> StockList { get; set; }

        public Stocks NewStock { get; set; } = new Stocks();

        public StocksVM()
        {
            // Inițializare listă de produse și de stocuri
            ProductList = new ObservableCollection<Product>(stocksBLL.GetAllProducts());
            StockList = new ObservableCollection<Stocks>(stocksBLL.GetAllStocks());
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<object>(_ =>
                    {
                        //NewStock.SellPrice = stocksBLL.CalculateSellingPrice(NewStock.PurchasePrice);
                        stocksBLL.AddStocks(NewStock);
                        StockList = new ObservableCollection<Stocks>(stocksBLL.GetAllStocks()); // Actualizare lista de stocuri
                        NewStock = new Stocks(); // Resetare obiect NewStock după adăugare
                    });
                }
                return addCommand;
            }
        }

       

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Stocks>(stocksBLL.DeleteStocks);
                }
                return deleteCommand;
            }
        }
    }
}
