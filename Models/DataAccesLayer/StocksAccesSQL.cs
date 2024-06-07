using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace SupermarketMVP.Models.DataAccesLayer
{
    public class StocksAccesSQL
    {
        public ObservableCollection<Stocks> GetAllStocks()
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spStocksSelectAllActives", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    ObservableCollection<Stocks> result = new ObservableCollection<Stocks>();
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stocks s = new Stocks
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Amount = reader.GetInt32(reader.GetOrdinal("Amount")),
                                UnitName = reader.GetString(reader.GetOrdinal("Unit")),
                                ExpirationDate = reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                                SupplyDate = reader.GetDateTime(reader.GetOrdinal("SupplyDate")),
                                PurchasePrice = (float)reader.GetDouble(reader.GetOrdinal("PurchasePrice")),
                                SellPrice = (float)reader.GetDouble(reader.GetOrdinal("SellPrice"))
                            };
                            result.Add(s);
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    // Loghează sau tratează eroarea
                    throw new Exception("An error occurred while retrieving stocks.", ex);
                }
            }
        }


        public void AddStocks(Stocks stocks)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertStocks", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Amount", stocks.Amount);
                cmd.Parameters.AddWithValue("@Unit", stocks.UnitName);
                cmd.Parameters.AddWithValue("@ExpirationDate", stocks.ExpirationDate);
                cmd.Parameters.AddWithValue("@SupplyDate", stocks.SupplyDate);
                cmd.Parameters.AddWithValue("@PurchasePrice", stocks.PurchasePrice);
                cmd.Parameters.AddWithValue("@SellPrice", stocks.SellPrice);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStocks(Stocks stocks)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteStocks", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductID", stocks.ProductID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            ObservableCollection<Product> productList = new ObservableCollection<Product>();
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            BarCode = reader["BarCode"].ToString(),
                            CategoryID = (int)reader["CategoryID"],
                            ProducerID = (int)reader["ProducerID"],
                            ReceiptID = reader.IsDBNull(reader.GetOrdinal("ReceiptID")) ? (int?)null : (int)reader["ReceiptID"],
                            OfferID = reader.IsDBNull(reader.GetOrdinal("OfferID")) ? (int?)null : (int)reader["OfferID"]
                        };
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
    }
}
