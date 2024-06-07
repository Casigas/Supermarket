using SupermarketMVP.Exceptions;
using SupermarketMVP.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models.BusinessLogisticLayer
{
    public class ProductBLL
    {
        public ObservableCollection<Product> ProductList { get; set; }
        ProductAccesSQL productSQL = new ProductAccesSQL();
        public ObservableCollection<Product> GetAllProducts()
        {
            return productSQL.GetAllProducts();
        }
        public void GetProductsForCategory(Category category)
        {
            ProductList.Clear();
            var products = productSQL.GetAllProductsForCategory(category);
            foreach (var pd in products)
            {
                ProductList.Add(pd);
            }
        }

        public void GetProductsForOffer(Offer offer)
        {
            ProductList.Clear();
            var products = productSQL.GetAllProductsForOffer(offer);
            foreach (var pd in products)
            {
                ProductList.Add(pd);
            }
        }
        public void GetProductsForProducer(Producer producer)
        {
            ProductList.Clear();
            var products = productSQL.GetAllProductsForProducer(producer);
            foreach (var pd in products)
            {
                ProductList.Add(pd);
            }
        }
        public void GetProductsForReceipt(Receipt receipt)
        {
            ProductList.Clear();
            var products = productSQL.GetAllProductsForReceipt(receipt);
            foreach (var pd in products)
            {
                ProductList.Add(pd);
            }
        }
        public void AddProduct(Product product)
        {
            if (productSQL.ProductExists(product.BarCode))
            {
                throw new AgendaException("Bar code already exists!");
            }
            productSQL.AddProduct(product);
            ProductList.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new AgendaException("Select a product!");
            }
            if (string.IsNullOrEmpty(product.ProductName))
            {
                throw new AgendaException("Product name must be specified!");
            }
            productSQL.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new AgendaException("Product name must be specified!");
            }
            productSQL.DeleteProduct(product);
            ProductList.Remove(product);
        }

        public ObservableCollection<Product> SearchProductsByName(string name)
        {
            return productSQL.SearchProductsByName(name);
        }

        public ObservableCollection<Product> SearchProductsByBarcode(string barcode)
        {
            return productSQL.SearchProductsByBarcode(barcode);
        }

        public ObservableCollection<Product> SearchProductsByExpirationDate(DateTime expirationDate)
        {
            return productSQL.SearchProductsByExpirationDate(expirationDate);
        }

        public ObservableCollection<Product> SearchProductsByProducer(Producer producer)
        {
            return productSQL.SearchProductsByProducer(producer);
        }

        public ObservableCollection<Product> SearchProductsByCategory(Category category)
        {
            return productSQL.SearchProductsByCategory(category);
        }

    }
}
