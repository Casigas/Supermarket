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
    public class UserAndReceiptsVM
    {
        public Dictionary<User, ObservableCollection<Receipt>> Agenda { get; set; }

        public UserAndReceiptsVM()
        {
            UserBLL userBLL = new UserBLL();
            Agenda = new Dictionary<User, ObservableCollection<Receipt>>();
            foreach (User user in userBLL.GetAllUsers())
            {
                ReceiptBLL receiptBLL = new ReceiptBLL();
                receiptBLL.GetReceiptsForUser(user);
                Agenda.Add(user, receiptBLL.ReceiptList);
            }
        }
    }
}
