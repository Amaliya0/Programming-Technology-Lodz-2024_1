using Task2Project.Presentation.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Task2Project.Presentation.Views
{
    public partial class UserMasterView : Window
    {
        public UserMasterView(UserMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
