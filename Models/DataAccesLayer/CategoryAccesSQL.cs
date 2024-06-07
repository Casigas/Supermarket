using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SupermarketMVP.Models.DataAccesLayer
{
    public class CategoryAccesSQL
    {
        public ObservableCollection<Category> GetAllCategories()
        {
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spCategorySelectAllActives", con);
                ObservableCollection<Category> result = new ObservableCollection<Category>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.CategoryID = (int)(reader[0]);
                    c.CategoryName = (string)reader[1];
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddCategory(Category category)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@CategoryName", category.CategoryName);
                
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCategory(Category category)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCategory = new SqlParameter("@CategoryID", category.CategoryID);
                cmd.Parameters.Add(paramIDCategory);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@CategoryID", category.CategoryID);
                SqlParameter paramNume = new SqlParameter("@CategoryName", category.CategoryName);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool CategoryExists(string categoryName)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spCategoryExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CategoryName", categoryName));
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        
    }
}
