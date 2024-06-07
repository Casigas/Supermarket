using SupermarketMVP.Models;
using SupermarketMVP.Models.BusinessLogisticLayer;
using SupermarketMVP.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupermarketMVP.ViewModels
{
    public class OfferVM : BasePropertyChanged
    {
        private OfferBLL offerBLL = new OfferBLL();
        public OfferVM()
        {
            OfferList = offerBLL.GetAllOffers();
        }

        #region Data Members

        private ObservableCollection<Offer> offerList;
        public ObservableCollection<Offer> OfferList
        {
            get => offerList;
            set
            {
                offerList = value;
                NotifyPropertyChanged("OfferList");
            }
        }

        private Offer selectedOffer;
        public Offer SelectedOffer
        {
            get => selectedOffer;
            set
            {
                selectedOffer = value;
                NotifyPropertyChanged("SelectedOffer");
            }
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Offer>(offerBLL.AddOffer);
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
                    updateCommand = new RelayCommand<Offer>(offerBLL.UpdateOffer);
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
                    deleteCommand = new RelayCommand<Offer>(offerBLL.DeleteOffer);
                }
                return deleteCommand;
            }
        }

        #endregion
    }
}
