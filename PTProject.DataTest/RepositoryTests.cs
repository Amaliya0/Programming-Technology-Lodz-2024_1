using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Task2Project.Data;

namespace Task2Project.DataTest
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository<User> _userRepository;
        private IRepository<Good> _goodRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new RepositoryStub<User>();
            _goodRepository = new RepositoryStub<Good>();
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            var user1 = new User { Id = 1, UserName = "Vlad" };
            var user2 = new User { Id = 2, UserName = "Amaliya" };
            _userRepository.Add(user1);
            _userRepository.Add(user2);

            var users = _userRepository.GetAll();

            Assert.AreEqual(2, users.Count());
            Assert.AreEqual(user1, users.First());
            Assert.AreEqual(user2, users.Last());
        }

    }
}
