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
    public class ProducerAccesSQL
    {
        public ObservableCollection<Producer> GetAllProducers()
        {
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spProducerSelectAllActives", con);
                ObservableCollection<Producer> result = new ObservableCollection<Producer>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producer p = new Producer();
                    p.ProducerID= (int)(reader[0]);
                    p.ProducerName = (string)reader[1];
                    p.Country = (string)reader[2];
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
        public void AddProducer(Producer producer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@ProducerName", producer.ProducerName);
                SqlParameter paramCountry = new SqlParameter("@Country", producer.Country);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramCountry);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProducer(Producer producer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDProducer = new SqlParameter("@ProducerID", producer.ProducerID);
                cmd.Parameters.Add(paramIDProducer);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProducer(Producer producer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ProducerID", producer.ProducerID);
                SqlParameter paramNume = new SqlParameter("@ProducerName", producer.ProducerName);
                SqlParameter paramCountry = new SqlParameter("@Country", producer.Country);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramCountry);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool ProducerExists(string producerName)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spProducerExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProducerName", producerName));
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
