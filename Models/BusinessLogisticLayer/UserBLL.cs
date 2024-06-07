using SupermarketMVP.Exceptions;
using SupermarketMVP.Models.DataAccesLayer;
using System.Collections.ObjectModel;

namespace SupermarketMVP.Models.BusinessLogisticLayer
{
    public class UserBLL
    {
        public ObservableCollection<User> UserList { get; set; }
        UserAccesSQL userSQL = new UserAccesSQL();

        public UserBLL()
        {
            // Inițializează UserList cu o colecție goală
            UserList = new ObservableCollection<User>();
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return userSQL.GetAllUsers();
        }

        public void AddUser(User user)
        {
            //if (userSQL.UserExists(user.UserName))
            //{
            //    throw new AgendaException("User name already exists!");
            //}
            userSQL.AddUser(user);
            UserList.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new AgendaException("Select a user!");
            }
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new AgendaException("User name must be specified!");
            }
            userSQL.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new AgendaException("User name must be specified!");
            }
            userSQL.DeleteUser(user);
            UserList.Remove(user);
        }
    }
}
