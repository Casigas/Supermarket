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
    public class ProducerBLL
    {
        public ObservableCollection<Producer> ProducerList { get; set; }
        ProducerAccesSQL producerSQL = new ProducerAccesSQL();
        public ObservableCollection<Producer> GetAllProducers()
        {
            return producerSQL.GetAllProducers();
        }
        public void AddProducer(Producer producer)
        {
            if (producerSQL.ProducerExists(producer.ProducerName))
            {
                throw new AgendaException("Producer already exists!");
            }
            producerSQL.AddProducer(producer);
            ProducerList.Add(producer);
        }
        public void UpdateProducer(Producer producer)
        {
            if (producer == null)
            {
                throw new AgendaException("Select a producer!");
            }
            if (string.IsNullOrEmpty(producer.ProducerName))
            {
                throw new AgendaException("Producer name must be specified!");
            }
            producerSQL.UpdateProducer(producer);
        }

        public void DeleteProducer(Producer producer)
        {
            if (producer == null)
            {
                throw new AgendaException("Producer name must be specified!");
            }
            else
            {
                ProductAccesSQL productSQL = new ProductAccesSQL();
                int productCount = productSQL.CountProductsInProducer(producer.ProducerID.Value);
                if (productCount > 0)
                {
                    throw new AgendaException("In this producer still exist products!");
                }
            }
            producerSQL.DeleteProducer(producer);
            ProducerList.Remove(producer);
        }
    }
}
