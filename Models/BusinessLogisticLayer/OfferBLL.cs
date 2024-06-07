using SupermarketMVP.Exceptions;
using SupermarketMVP.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.Models.BusinessLogisticLayer
{
    public class OfferBLL
    {
        public ObservableCollection<Offer> OfferList { get; set; }
        OfferAccesSQL offerSQL = new OfferAccesSQL();
        public ObservableCollection<Offer> GetAllOffers()
        {
            return offerSQL.GetAllOffers();
        }
        public void AddOffer(Offer offer)
        {
            
            offerSQL.AddOffer(offer);
            OfferList.Add(offer);
        }
        public void UpdateOffer(Offer offer)
        {
            if (offer == null)
            {
                throw new AgendaException("Select an offer!");
            }
            if (string.IsNullOrEmpty(offer.Reason))
            {
                throw new AgendaException("Reason must be specified!");
            }
            offerSQL.UpdateOffer(offer);
        }

        public void DeleteOffer(Offer offer)
        {
            if (offer == null)
            {
                throw new AgendaException("Offer reason must be specified!");
            }
            offerSQL.DeleteOffer(offer);
            OfferList.Remove(offer);
        }
    }
}
