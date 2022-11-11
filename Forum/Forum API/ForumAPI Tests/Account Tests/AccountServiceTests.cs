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
        private AccountService accountService;
        private Account accountOne, accountTwo;
        private List<Account> accounts;
        private Expression<Func<Account, bool>> expressionAccount;
        private readonly string username = "username 1";
        private Mock<IAccountRoleRepository> mockAccountRoleRepository;
        private Expression<Func<AccountRole, bool>> expressionAccountRole;
        private AccountRole accountRoleOne, accountRoleTwo;
        private List<AccountRole> accountRoles;
        private readonly int requestedRolePriority = 1;

        [SetUp]
        public void SetUp()
        {
            mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRoleRepository = new Mock<IAccountRoleRepository>();

            accountOne = new Account("username 1", "password 1", "email 1");
            accountTwo = new Account("username 2", "password 2", "email 2");

            expressionAccount = role => role.AccountUsername == username;

            accounts = new List<Account>
            {
                accountOne,
                accountTwo
            };

            accountRoleOne = new AccountRole(1, "default user");
            accountRoleTwo = new AccountRole(2, "exampleRoleDescription");

            expressionAccountRole = role => role.RolePriority == requestedRolePriority;

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
        public async Task CreateAccountRole_ShouldCallCreateAndSaveChanges()
        {
            await accountService.CreateAccount(accountOne);

            mockAccountRepository.Verify(mock => mock.Create(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public async Task DeleteAccountRole_ShouldCallDeleteAndSaveChanges()
        {
            await accountService.DeleteAccount(accountOne.AccountId);

            mockAccountRepository.Verify(mock => mock.Delete(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public async Task GetAllAccountRoles_ShouldCallFindAll()
        {
            var result = await accountService.GetAllAccounts();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAccountRolesByRolePriority_ShouldCallWhere()
        {
            var result = await accountService.GetAccountByCriteria(expressionAccount);

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateAccountRole_ShouldCallUpdate()
        {
            await accountService.UpdateAccount(accountOne, accountOne.AccountId);

            mockAccountRepository.Verify(mock => mock.Update(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public void UpdateAccountRole_FindByCriteriaShouldThrowException()
        {
            mockAccountRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Throws<EntityNotFoundException>();

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountService
            .UpdateAccount(It.IsAny<Account>(), It.IsAny<Guid>()));
        }

        [Test]
        public void DeleteAccountRole_FindByCriteriaShouldThrowException()
        {
            mockAccountRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<Account, bool>>>()))
                .Throws<EntityNotFoundException>();

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountService
                .DeleteAccount(It.IsAny<Guid>()));
        }
    }
}

