using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketMVP.ViewModels
{
    public class OfferAndProductsVM
    {
        public Dictionary<Offer, ObservableCollection<Product>> Agenda { get; set; }

        public OfferAndProductsVM()
        {
            OfferBLL offerBLL = new OfferBLL();
            Agenda = new Dictionary<Offer, ObservableCollection<Product>>();
            foreach (Offer offer in offerBLL.GetAllOffers())
            {
                ProductBLL productBLL = new ProductBLL();
                productBLL.GetProductsForOffer(offer);
                Agenda.Add(offer, productBLL.ProductList);
            }
        }
    }
}
