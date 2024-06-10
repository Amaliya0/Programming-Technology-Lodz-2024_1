using System.Windows;
using System.Windows.Controls;
using Task2Project.Presentation.ViewModels;


namespace Task2Project.Presentation.Views
{
    public partial class GoodMasterView : Window
    {
        public GoodMasterView(GoodMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
