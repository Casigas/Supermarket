using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using SupermarketMVP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class ReceiptVM : BasePropertyChanged
    {
        ReceiptBLL receiptBLL = new ReceiptBLL();
        public ReceiptVM()
        {
            ReceiptList = receiptBLL.GetAllReceipts();
        }

        #region Data Members

        public ObservableCollection<Receipt> ReceiptList
        {
            get => receiptBLL.ReceiptList;
            set => receiptBLL.ReceiptList = value;
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Receipt>(receiptBLL.AddReceipt);
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
                    deleteCommand = new RelayCommand<Receipt>(receiptBLL.DeleteReceipt);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
