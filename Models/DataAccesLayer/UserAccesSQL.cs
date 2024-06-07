using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace SupermarketMVP.Models.DataAccesLayer
{
    public class UserAccesSQL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUsersSelectAllActives", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    ObservableCollection<User> result = new ObservableCollection<User>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User u = new User();
                        u.UserID = (int)reader[0];
                        u.UserName = (string)reader[1];
                        u.Password = (string)reader[2];
                        u.Type = (string)reader[3];
                        result.Add(u);
                    }

                    return result;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramNume = new SqlParameter("@UserName", user.UserName);
                    SqlParameter paramPassword = new SqlParameter("@Password", user.Password);
                    SqlParameter paramType = new SqlParameter("@Type", user.Type);

                    cmd.Parameters.Add(paramNume);
                    cmd.Parameters.Add(paramPassword);
                    cmd.Parameters.Add(paramType);

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramIDUser = new SqlParameter("@UserID", user.UserID);
                    cmd.Parameters.Add(paramIDUser);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramID = new SqlParameter("@UserID", user.UserID);
                    SqlParameter paramNume = new SqlParameter("@UserName", user.UserName);
                    SqlParameter paramPassword = new SqlParameter("@Password", user.Password);
                    SqlParameter paramType = new SqlParameter("@Type", user.Type);
                    cmd.Parameters.Add(paramID);
                    cmd.Parameters.Add(paramNume);
                    cmd.Parameters.Add(paramPassword);
                    cmd.Parameters.Add(paramType);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public bool UserExists(string userName)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUserExists", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserName", userName));
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
