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
    public class ProducerAndProductsVM
    {
        public Dictionary<Producer, ObservableCollection<Product>> Agenda { get; set; }

        public ProducerAndProductsVM()
        {
            ProducerBLL producerBLL = new ProducerBLL();
            Agenda = new Dictionary<Producer, ObservableCollection<Product>>();
            foreach (Producer producer in producerBLL.GetAllProducers())
            {
                ProductBLL productBLL = new ProductBLL();
                productBLL.GetProductsForProducer(producer);
                Agenda.Add(producer, productBLL.ProductList);
            }
        }
    }
}
