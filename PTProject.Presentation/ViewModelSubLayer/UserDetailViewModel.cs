using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Task2Project.Presentation.Models;

namespace Task2Project.Presentation.ViewModels
{
    public class UserDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        private ObservableCollection<Good> _purchasedGoods;
        public ObservableCollection<Good> PurchasedGoods
        {
            get { return _purchasedGoods; }
            set
            {
                _purchasedGoods = value;
                OnPropertyChanged("PurchasedGoods");
            }
        }

        public UserDetailViewModel(User user, IEnumerable<Good> purchasedGoods)
        {
            User = user;
            PurchasedGoods = new ObservableCollection<Good>(purchasedGoods);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
