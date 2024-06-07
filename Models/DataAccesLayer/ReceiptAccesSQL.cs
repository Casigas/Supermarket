using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models.DataAccesLayer
{
    public class ReceiptAccesSQL
    {
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spReceiptSelectAllActives", con);
                ObservableCollection<Receipt> result = new ObservableCollection<Receipt>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Receipt r = new Receipt();
                    r.ReceiptID = (int)(reader[0]);
                    r.Date = (DateTime)reader[1];
                    r.Profit = (float)reader[2];
                    r.UserID = (int)(reader[3]);
                    result.Add(r);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Receipt> GetAllReceiptsForUser(User user)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Receipt> result = new ObservableCollection<Receipt>();
                SqlCommand cmd = new SqlCommand("spGetReceiptsForUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCategory = new SqlParameter("@UserID", user.UserID);
                cmd.Parameters.Add(paramIDCategory);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Receipt()
                    {
                        ReceiptID = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Profit = reader.GetFloat(2),
                        UserID = reader.GetInt32(3)  
                    });
                }
                return result;
            }
        }
        public void AddReceipt(Receipt receipt)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDate = new SqlParameter("@Date", receipt.Date);
                SqlParameter paramProfit = new SqlParameter("@Pofit", receipt.Profit);
                SqlParameter paramUserID = new SqlParameter("@UserID", receipt.UserID);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramProfit);
                cmd.Parameters.Add(paramUserID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteReceipt(Receipt receipt)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDReceipt = new SqlParameter("@ReceiptID", receipt.ReceiptID);
                cmd.Parameters.Add(paramIDReceipt);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
