using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace SupermarketMVP.Models.DataAccesLayer
{
    public class ProductAccesSQL
    {
        public ObservableCollection<Product> GetAllProducts()
        {
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spProductSelectAllActives", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductID = (int)(reader[0]);
                    p.ProductName = (string)reader[1];
                    p.BarCode = (string)reader[2];
                    p.CategoryID = (int)reader[3];
                    p.ProducerID = (int)reader[4];
                    p.ReceiptID = reader.IsDBNull(5) ? null : (int?)reader[5];
                    p.OfferID=reader.IsDBNull (6) ? null : (int?)reader[6];
                    if (p.CategoryID.HasValue)
                    {
                        p.Category = GetCategoryById(p.CategoryID.Value);
                    }
                    if (p.ProducerID.HasValue)
                    {
                        p.Producer = GetProducerById(p.ProducerID.Value);
                    }
                    if (p.OfferID.HasValue)
                    {
                        p.Offer = GetOfferById(p.OfferID.Value);
                    }
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Product> GetAllProductsForCategory(Category category)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spGetProductsForCategory", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCategory = new SqlParameter("@CategoryID", category.CategoryID);
                cmd.Parameters.Add(paramIDCategory);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.GetInt32(5),
                        OfferID = reader.GetInt32(6)
                    });
                }
                return result;
            }
        }
        public ObservableCollection<Product> GetAllProductsForOffer(Offer offer)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spGetProductsForOffer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCategory = new SqlParameter("@OfferID", offer.OfferID);
                cmd.Parameters.Add(paramIDCategory);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.GetInt32(5),
                        OfferID = reader.GetInt32(6)
                    });
                }
                return result;
            }
        }
        public ObservableCollection<Product> GetAllProductsForProducer(Producer producer)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spGetProductsForProducer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDProduct = new SqlParameter("@ProducerID", producer.ProducerID);
                cmd.Parameters.Add(paramIDProduct);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.GetInt32(5),
                        OfferID = reader.GetInt32(6)
                    });
                }
                
                return result;
            }
        }
        private Category GetCategoryById(int categoryId)
        {
            // Method to fetch Category by ID from the database
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spGetCategoryById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CategoryID", categoryId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Category
                    {
                        CategoryID = reader.GetInt32(0),
                        CategoryName = reader.GetString(1)
                    };
                }
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        private Producer GetProducerById(int producerId)
        {
            // Method to fetch Producer by ID from the database
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spGetProducerById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProducerID", producerId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Producer
                    {
                        ProducerID = reader.GetInt32(0),
                        ProducerName = reader.GetString(1),
                        Country = reader.GetString(2)
                    };
                }
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        private Offer GetOfferById(int offerId)
        {
            // Method to fetch Offer by ID from the database
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spGetOfferById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OfferID", offerId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Offer
                    {
                        OfferID = reader.GetInt32(0),
                        Reason = reader.GetString(1)
                    };
                }
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Product> GetAllProductsForReceipt(Receipt receipt)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spGetProductsForReceipt", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCategory = new SqlParameter("@ReceiptID", receipt.ReceiptID);
                cmd.Parameters.Add(paramIDCategory);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.GetInt32(5),
                        OfferID = reader.GetInt32(6)
                    });
                }
                return result;
            }
        }
        public void AddProduct(Product product)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@ProductName", product.ProductName);
                SqlParameter paramBarCode = new SqlParameter("@BarCode", product.BarCode);
                SqlParameter paramIDCategory = new SqlParameter("@CategoryID", product.CategoryID);
                SqlParameter paramIDProducer = new SqlParameter("@ProducerID", product.ProducerID);
                SqlParameter paramIDReceipt = new SqlParameter("@ReceiptID", SqlDbType.Int);
                paramIDReceipt.Value = (object)product.ReceiptID ?? DBNull.Value;
                SqlParameter paramIDOffer = new SqlParameter("@OfferID", SqlDbType.Int);
                paramIDOffer.Value = (object)product.OfferID ?? DBNull.Value;

                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramBarCode);
                cmd.Parameters.Add(paramIDCategory);
                cmd.Parameters.Add(paramIDProducer);
                cmd.Parameters.Add(paramIDReceipt);
                cmd.Parameters.Add(paramIDOffer);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(Product product)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDProduct = new SqlParameter("@ProductID", product.ProductID);
                cmd.Parameters.Add(paramIDProduct);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ProductID", product.ProductID);
                SqlParameter paramNume = new SqlParameter("@ProductName", product.ProductName);
                SqlParameter paramCode = new SqlParameter("@BarCode", product.BarCode);
                SqlParameter paraCategoryID = new SqlParameter("@CategoryID", product.CategoryID);
                SqlParameter paraProducerID = new SqlParameter("@ProducerID", product.ProducerID);
                //SqlParameter paraReceiptID = new SqlParameter("@ReceiptID", product.ReceiptID);
                //SqlParameter paraOfferID = new SqlParameter("@OfferID", product.OfferID);
                SqlParameter paraReceiptID = new SqlParameter("@ReceiptID", SqlDbType.Int);
                if (product.ReceiptID.HasValue)
                    paraReceiptID.Value = product.ReceiptID.Value;
                else
                    paraReceiptID.Value = DBNull.Value;

                SqlParameter paraOfferID = new SqlParameter("@OfferID", SqlDbType.Int);
                if (product.OfferID.HasValue)
                    paraOfferID.Value = product.OfferID.Value;
                else
                    paraOfferID.Value = DBNull.Value;

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramCode);
                cmd.Parameters.Add(paraCategoryID);
                cmd.Parameters.Add(paraProducerID);
                cmd.Parameters.Add(paraReceiptID);
                cmd.Parameters.Add(paraOfferID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public int CountProductsInCategory(int categoryId)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCountProductsInCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CategoryID", categoryId));
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
        public int CountProductsInProducer(int producerId)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCountProductsInProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProducerID", producerId));
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
        public bool ProductExists(string barCode)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spProductExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BarCode", barCode));
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public ObservableCollection<Product> SearchProductsByName(string name)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spSearchProductsByName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@ProductName", name);
                cmd.Parameters.Add(paramName);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                        OfferID = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                    });
                }
                return result;
            }
        }

        public ObservableCollection<Product> SearchProductsByBarcode(string barcode)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spSearchProductsByBarcode", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramBarcode = new SqlParameter("@BarCode", barcode);
                cmd.Parameters.Add(paramBarcode);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                        OfferID = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                    });
                }
                return result;
            }
        }

        public ObservableCollection<Product> SearchProductsByExpirationDate(DateTime expirationDate)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spSearchProductsByExpirationDate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramExpirationDate = new SqlParameter("@ExpirationDate", expirationDate);
                cmd.Parameters.Add(paramExpirationDate);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                        OfferID = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                    });
                }
                return result;
            }
        }

        public ObservableCollection<Product> SearchProductsByProducer(Producer producer)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spSearchProductsByProducer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramProducerID = new SqlParameter("@ProducerID", producer.ProducerID);
                cmd.Parameters.Add(paramProducerID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                        OfferID = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                    });
                }
                return result;
            }
        }

        public ObservableCollection<Product> SearchProductsByCategory(Category category)
        {
            using (SqlConnection connection = ConnectionSQL.Connection)
            {
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlCommand cmd = new SqlCommand("spSearchProductsByCategory", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCategoryID = new SqlParameter("@CategoryID", category.CategoryID);
                cmd.Parameters.Add(paramCategoryID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        BarCode = reader.GetString(2),
                        CategoryID = reader.GetInt32(3),
                        ProducerID = reader.GetInt32(4),
                        ReceiptID = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                        OfferID = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                    });
                }
                return result;
            }
        }
    }
}
