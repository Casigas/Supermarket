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
    public class UserVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();
        public UserVM()
        {
            UserList = userBLL.GetAllUsers();
        }

        #region Data Members

        public ObservableCollection<User> UserList
        {
            get => userBLL.UserList;
            set => userBLL.UserList = value;
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
                    addCommand = new RelayCommand<User>(userBLL.AddUser);
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
                    updateCommand = new RelayCommand<User>(userBLL.UpdateUser);
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
                    deleteCommand = new RelayCommand<User>(userBLL.DeleteUser);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
