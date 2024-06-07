using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.ViewModels
{
    public class ReceiptAndProductsVM
    {
        public Dictionary<Receipt, ObservableCollection<Product>> Agenda { get; set; }

        public ReceiptAndProductsVM()
        {
            ReceiptBLL receiptBLL = new ReceiptBLL();
            Agenda = new Dictionary<Receipt, ObservableCollection<Product>>();
            foreach (Receipt receipt in receiptBLL.GetAllReceipts())
            {
                ProductBLL productBLL = new ProductBLL();
                productBLL.GetProductsForReceipt(receipt);
                Agenda.Add(receipt, productBLL.ProductList);
            }
        }
    }
}
