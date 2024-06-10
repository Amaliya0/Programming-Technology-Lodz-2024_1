
namespace Task2Project.Service
{
    public interface IServiceFactory
    {
        IUserService CreateUserService();
        IGoodService CreateGoodService();
        IProcessStateService CreateProcessStateService();
    }
}

