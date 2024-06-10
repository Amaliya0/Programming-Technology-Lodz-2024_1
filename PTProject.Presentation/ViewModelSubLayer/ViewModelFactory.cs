using Task2Project.Presentation.Models;

namespace Task2Project.Presentation.ViewModels
{
    public class ViewModelFactory
    {
        private readonly ModelFactory _modelFactory;

        public ViewModelFactory(string connectionString)
        {
            _modelFactory = new ModelFactory(connectionString);
        }

        public UserMasterViewModel CreateUserMasterViewModel()
        {
            UserModel userModel = _modelFactory.CreateUserModel();
            return new UserMasterViewModel(userModel);
        }

        public GoodMasterViewModel CreateGoodMasterViewModel()
        {
            GoodModel goodModel = _modelFactory.CreateGoodModel();
            return new GoodMasterViewModel(goodModel);
        }
    }
}
