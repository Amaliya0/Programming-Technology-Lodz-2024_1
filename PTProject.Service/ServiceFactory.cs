using Task2Project.Data;

namespace Task2Project.Service
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly string _connectionString;
        private Task2ProjectDataContext _context;
        private IUnitOfWork _unitOfWork;

        public ServiceFactory(string connectionString)
        {
            _connectionString = connectionString;
            _context = new Task2ProjectDataContext(_connectionString);
            _unitOfWork = new UnitOfWork(_context);
        }

        public IUserService CreateUserService()
        {
            return new UserService(_unitOfWork);
        }

        public IGoodService CreateGoodService()
        {
            return new GoodService(_unitOfWork);
        }

        public IProcessStateService CreateProcessStateService()
        {
            IGoodService goodService = new GoodService(_unitOfWork);
            return new ProcessStateService(_unitOfWork, goodService);
        }
    }
}

