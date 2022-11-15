using Forum_API;
using Forum_API.Controllers;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
using System.Linq.Expressions;
using System.Net;

namespace ForumAPI_Tests.Account_Tests
{
    internal class AccountControllerTests
    {
        private Mock<AccountService> mockAccountService;
        private Mock<IAccountRepository> mockAccountRepository;
        private Mock<IAccountRoleRepository> mockAccountRoleRepository;
        private AccountController accountController;

        private Account accountOne, accountTwo;
        private ICollection<Account> accounts;

        private readonly static int minimumAccountPoints = 50;

        private readonly Expression<Func<Account, bool>> expression =
            role => role.Points > minimumAccountPoints;

        [SetUp]
        public void SetUp()
        {
            mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRoleRepository = new Mock<IAccountRoleRepository>();

            mockAccountService = new Mock<AccountService>(mockAccountRepository.Object, mockAccountRoleRepository.Object);

            accountController = new AccountController(mockAccountService.Object);

            accountOne = new Account("username 1", "password 1", "email 1");
            accountTwo = new Account("username 2", "password 2", "email 2");

            accounts = new List<Account>
            {
                accountOne,
                accountTwo
            };

            mockAccountService.Setup(mock => mock.CreateAccount(It.IsAny<AccountRequest>(), It.IsAny<string>()))
                .Verifiable();

            mockAccountService.Setup(mock => mock.DeleteAccount(It.IsAny<Guid>()))
                .Verifiable();

            mockAccountService.Setup(mock => mock.UpdateAccount(It.IsAny<AccountRequest>(), It.IsAny<Guid>()))
                .Verifiable();

            mockAccountService.Setup(mock => mock.GetAllAccounts())
                .Returns(Task.FromResult(accounts.AsEnumerable()))
                .Verifiable();

            mockAccountService.Setup(mock => mock.GetAccountByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(Task.FromResult(accounts.AsQueryable().Where(expression).AsEnumerable()))
                .Verifiable();
        }

        [Test]
        public async Task CreateAccount_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountController.CreateAccount(It.IsAny<AccountRequest>());

            mockAccountService.Verify(mock => mock.CreateAccount(It.IsAny<AccountRequest>(), It.IsAny<string>()), Times.Once);
            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task DeleteAccount_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountController.DeleteAccount(It.IsAny<Guid>());

            mockAccountService.Verify(mock => mock.DeleteAccount(It.IsAny<Guid>()), Times.Once);

            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task UpdateAccount_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountController.UpdateAccount(It.IsAny<AccountRequest>(), It.IsAny<Guid>());

            mockAccountService.Verify(mock => 
                mock.UpdateAccount(It.IsAny<AccountRequest>(), It.IsAny<Guid>()), Times.Once);

            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task GetAccountByGuid_ShouldReturnAccountList()
        {
            var expectedCount = 1;

            accountOne.Points = 100;
            accountTwo.Points = 20;

            var check = accounts;

            var result = await accountController.GetAccountWithPoints(minimumAccountPoints);

            mockAccountService.Verify(mock => mock
                .GetAccountByCriteria(It.IsAny<Expression<Func<Account, bool>>>()), Times.Once);

            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetAllAccount_ShouldReturnAll()
        {
            var expectedCount = accounts.Count;

            var result = await accountController.GetAllAccounts();


            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }
    }
}
