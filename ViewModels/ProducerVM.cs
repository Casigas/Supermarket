using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class ProducerVM : BasePropertyChanged
    {
        private ProducerBLL producerBLL = new ProducerBLL();
        private string producerName;
        private string country;

        public ProducerVM()
        {
            ProducerList = producerBLL.GetAllProducers();
        }

        #region Data Members

        public ObservableCollection<Producer> ProducerList
        {
            get => producerBLL.ProducerList;
            set
            {
                producerBLL.ProducerList = value;
                NotifyPropertyChanged(nameof(ProducerList));
            }
        }

        public string ProducerName
        {
            get => producerName;
            set
            {
                producerName = value;
                NotifyPropertyChanged(nameof(ProducerName));
            }
        }

        public string Country
        {
            get => country;
            set
            {
                country = value;
                NotifyPropertyChanged(nameof(Country));
            }
        }

        public Producer NewProducer { get; set; } = new Producer();

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<object>(_ =>
                    {
                        var producer = new Producer
                        {
                            ProducerName = ProducerName,
                            Country = Country
                        };
                        producerBLL.AddProducer(producer);
                        // Nu adăugăm direct în listă aici, ci doar resetăm inputurile
                        ProducerName = string.Empty;
                        Country = string.Empty;
                    });
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Producer>(producerBLL.UpdateProducer);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Producer>(producerBLL.DeleteProducer);
                }
                return deleteCommand;
            }
        }

        #endregion
    }
}
