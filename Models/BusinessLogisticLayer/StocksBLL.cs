using SupermarketMVP.Models.DataAccesLayer;
using System;
using System.Collections.ObjectModel;

namespace SupermarketMVP.Models.BusinessLogisticLayer
{
    public class StocksBLL
    {
        public ObservableCollection<Stocks> StocksList { get; set; }
        StocksAccesSQL stocksSQL = new StocksAccesSQL();

        // Constructor
        public StocksBLL()
        {
            StocksList = new ObservableCollection<Stocks>();
        }

        public ObservableCollection<Stocks> GetAllStocks()
        {
            return stocksSQL.GetAllStocks();
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            return stocksSQL.GetAllProducts();
        }

        public void AddStocks(Stocks stocks)
        {
            stocksSQL.AddStocks(stocks);
            StocksList.Add(stocks);
        }

        public void DeleteStocks(Stocks stocks)
        {
            stocksSQL.DeleteStocks(stocks);
            StocksList.Remove(stocks);
        }
        public decimal CalculateSellingPrice(float? purchasePrice)
        {
            if (purchasePrice.HasValue)
            {
                decimal purchasePriceDecimal = Convert.ToDecimal(purchasePrice.Value);
                // Simulăm aici calculul prețului de vânzare, adăugând un adaos comercial de 20%
                decimal markupPercentage = 0.20m;
                decimal sellingPrice = purchasePriceDecimal * (1 + markupPercentage);
                return sellingPrice;
            }
            else
            {
                throw new ArgumentException("Prețul de achiziție nu poate fi null.");
            }
        }
    }
}
