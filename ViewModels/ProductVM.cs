using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class ProductVM : BasePropertyChanged
    {
        private ProductBLL productBLL = new ProductBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private ProducerBLL producerBLL = new ProducerBLL();
        private OfferBLL offerBLL = new OfferBLL();

        public ProductVM()
        {
            ProductList = productBLL.GetAllProducts();
            CategoryList = categoryBLL.GetAllCategories();
            ProducerList = producerBLL.GetAllProducers();
            OfferList = offerBLL.GetAllOffers();
        }

        public ObservableCollection<Product> ProductList
        {
            get => productBLL.ProductList;
            set
            {
                productBLL.ProductList = value;
                NotifyPropertyChanged(nameof(ProductList));
            }
        }

        public ObservableCollection<Category> CategoryList { get; set; }
        public ObservableCollection<Producer> ProducerList { get; set; }
        public ObservableCollection<Offer> OfferList { get; set; }

        public Product NewProduct { get; set; } = new Product();

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<object>(_ =>
                    {
                        productBLL.AddProduct(NewProduct);
                        ProductList = productBLL.GetAllProducts();
                        NewProduct = new Product(); // Reset new product after adding
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
                    updateCommand = new RelayCommand<Product>(productBLL.UpdateProduct);
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
                    deleteCommand = new RelayCommand<Product>(productBLL.DeleteProduct);
                }
                return deleteCommand;
            }
        }
        // Metoda pentru căutarea produsului după nume
        public void SearchProductsByName(string name)
        {
            ProductList = productBLL.SearchProductsByName(name);
        }

        // Metoda pentru căutarea produsului după cod de bare
        public void SearchProductsByBarcode(string barcode)
        {
            ProductList = productBLL.SearchProductsByBarcode(barcode);
        }

        // Metoda pentru căutarea produsului după dată de expirare
        public void SearchProductsByExpirationDate(DateTime expirationDate)
        {
            ProductList = productBLL.SearchProductsByExpirationDate(expirationDate);
        }

        // Metoda pentru căutarea produsului după producător
        public void SearchProductsByProducer(Producer producer)
        {
            ProductList = productBLL.SearchProductsByProducer(producer);
        }

        // Metoda pentru căutarea produsului după categorie
        public void SearchProductsByCategory(Category category)
        {
            ProductList = productBLL.SearchProductsByCategory(category);
        }

        // Comenzi pentru căutarea produsului
        public ICommand SearchByNameCommand { get; private set; }
        public ICommand SearchByBarcodeCommand { get; private set; }
        public ICommand SearchByExpirationDateCommand { get; private set; }
        public ICommand SearchByProducerCommand { get; private set; }
        public ICommand SearchByCategoryCommand { get; private set; }

    }
}
