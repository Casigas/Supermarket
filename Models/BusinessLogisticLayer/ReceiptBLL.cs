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
    public class ReceiptBLL
    {
        public ObservableCollection<Receipt> ReceiptList { get; set; }
        ReceiptAccesSQL receiptSQL = new ReceiptAccesSQL();
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            return receiptSQL.GetAllReceipts();
        }
        public void GetReceiptsForUser(User user)
        {
            ReceiptList.Clear();
            var products = receiptSQL.GetAllReceiptsForUser(user);
            foreach (var pd in products)
            {
                ReceiptList.Add(pd);
            }
        }
        public void AddReceipt(Receipt receipt)
        {

            receiptSQL.AddReceipt(receipt);
            ReceiptList.Add(receipt);
        }
        

        public void DeleteReceipt(Receipt receipt)
        {

            receiptSQL.DeleteReceipt(receipt);
            ReceiptList.Remove(receipt);
        }
    }
}
