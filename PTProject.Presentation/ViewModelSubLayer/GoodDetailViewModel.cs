using System.ComponentModel;
using Task2Project.Presentation.Models;

namespace Task2Project.Presentation.ViewModels
{
    public class GoodDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Good _good;
        public Good Good
        {
            get { return _good; }
            set
            {
                _good = value;
                OnPropertyChanged("Good");
            }
        }

        public GoodDetailViewModel(Good good)
        {
            Good = good;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
