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
    public class OfferAccesSQL
    {
        public ObservableCollection<Offer> GetAllOffers()
        {
            SqlConnection con = ConnectionSQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("spOfferSelectAllActives", con);
                ObservableCollection<Offer> result = new ObservableCollection<Offer>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Offer o = new Offer();
                    o.OfferID = (int)(reader[0]);
                    o.Reason = (string)reader[1];
                    o.Discount = (int)reader[2];
                    o.StartDate = (DateTime)reader[3];
                    o.EndDate = (DateTime)reader[4];
                    result.Add(o);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddOffer(Offer offer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spInsertOffer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramReason = new SqlParameter("@Reason", offer.Reason);
                SqlParameter paramDiscount = new SqlParameter("@Discount", offer.Discount);
                SqlParameter paramStartDate = new SqlParameter("@StartDate", offer.StartDate);
                SqlParameter paramEndDate = new SqlParameter("@EndDate", offer.EndDate);
                cmd.Parameters.Add(paramReason);
                cmd.Parameters.Add(paramDiscount);
                cmd.Parameters.Add(paramStartDate);
                cmd.Parameters.Add(paramEndDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteOffer(Offer offer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteOffer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDOffer = new SqlParameter("@OfferID", offer.OfferID);
                cmd.Parameters.Add(paramIDOffer);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateOffer(Offer offer)
        {
            using (SqlConnection con = ConnectionSQL.Connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateOffer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@OfferID", offer.OfferID);
                SqlParameter paramReason = new SqlParameter("@Reason", offer.Reason);
                SqlParameter paramDiscount = new SqlParameter("@Discount", offer.Discount);
                SqlParameter paramStartDate = new SqlParameter("@StartDate", offer.StartDate);
                SqlParameter paramEndDate = new SqlParameter("@EndDate", offer.EndDate);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramReason);
                cmd.Parameters.Add(paramDiscount);
                cmd.Parameters.Add(paramStartDate);
                cmd.Parameters.Add(paramEndDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
