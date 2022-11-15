using Forum_API.Exceptions;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests.Account_Tests
{
    internal class AccountServiceTests
    {
        private Mock<IAccountRepository> mockAccountRepository;
        private Mock<IAccountRoleRepository> mockAccountRoleRepository;
        private AccountService accountService;

        private Account accountOne, accountTwo;
        private List<Account> accounts;
        private AccountRole accountRoleOne, accountRoleTwo;
        private List<AccountRole> accountRoles;

        private static readonly string username = "username 1";
        private static readonly int requestedRolePriority = 1;

        private readonly Expression<Func<Account, bool>> expressionAccount = account
            => account.Username == username;
        private readonly Expression<Func<AccountRole, bool>> expressionAccountRole = accRole 
            => accRole.Priority == requestedRolePriority;

        [SetUp]
        public void SetUp()
        {
            mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRoleRepository = new Mock<IAccountRoleRepository>();

            accountOne = new Account("username 1", "password 1", "email 1");
            accountTwo = new Account("username 2", "password 2", "email 2");

            accounts = new List<Account>
            {
                accountOne,
                accountTwo
            };

            accountRoleOne = new AccountRole(1, "default user");
            accountRoleTwo = new AccountRole(2, "exampleRoleDescription");

            accountRoles = new List<AccountRole>
            {
                accountRoleOne,
                accountRoleTwo
            };

            mockAccountRoleRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()))
                .Returns(accountRoles.AsAsyncQueryable().Where(expressionAccountRole));

            mockAccountRepository.Setup(mock => mock.Create(It.IsAny<Account>())).Verifiable();
            mockAccountRepository.Setup(mock => mock.Update(It.IsAny<Account>())).Verifiable();
            mockAccountRepository.Setup(mock => mock.Delete(It.IsAny<Account>())).Verifiable();

            mockAccountRepository.Setup(mock => mock.SaveChanges()).Verifiable();

            mockAccountRepository.Setup(mock => mock.FindAll()).Returns(accounts.AsAsyncQueryable());

            mockAccountRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(accounts.AsAsyncQueryable().Where(expressionAccount));

            accountService = new AccountService(mockAccountRepository.Object, mockAccountRoleRepository.Object);
        }

        [Test]
        public async Task CreateAccount_ShouldCallCreateAndSaveChanges()
        {
            await accountService.CreateAccount(accountOne);

            mockAccountRepository.Verify(mock => mock.Create(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public async Task DeleteAccount_ShouldCallDeleteAndSaveChanges()
        {
            await accountService.DeleteAccount(accountOne.Id);

            mockAccountRepository.Verify(mock => mock.Delete(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public async Task GetAllAccount_ShouldCallFindAll()
        {
            var result = await accountService.GetAllAccounts();

            int expectedCount = 2;
            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetAccountsByUsername_ShouldCallFindByCriteria()
        {
            var result = await accountService.GetAccountByCriteria(expressionAccount);

            int expectedCount = 1;
            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task UpdateAccount_ShouldCallUpdate()
        {
            await accountService.UpdateAccount(accountOne, accountOne.Id);

            mockAccountRepository.Verify(mock => mock.Update(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public void UpdateAccount_FindByCriteriaShouldThrowException()
        {
            var emptyList = new List<Account>();

            mockAccountRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(emptyList.AsAsyncQueryable());

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountService
                .UpdateAccount(It.IsAny<Account>(), It.IsAny<Guid>()));
        }

        [Test]
        public void DeleteAccount_FindByCriteriaShouldThrowException()
        {
            var emptyList = new List<Account>();

            mockAccountRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(emptyList.AsAsyncQueryable());

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountService
                .DeleteAccount(It.IsAny<Guid>()));
        }
    }
}

