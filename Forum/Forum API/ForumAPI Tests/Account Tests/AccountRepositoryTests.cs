using Forum_API.Repository;
using Forum_API.Repository.Reposiory_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests.Account_Tests
{
    internal class AccountRepositoryTests
    {
        private DbContextOptions<ForumContext> dbContextOptions;
        private ForumContext forumContext;
        private AccountRepository accountRepository;
        private readonly string username = "username 5";

        private static async Task PopulateContextSet(ForumContext forumContext)
        {
            var accountsSet = new[]
            {
                new Account("username 1", "password 1", "email 1"),
                new Account("username 2", "password 2", "email 2"),
                new Account("username 3", "password 3", "email 3"),
                new Account("username 4", "password 4", "email 4"),
                new Account("username 5", "password 5", "email 5"),
                new Account("username 6", "password 6", "email 6")
            };

            forumContext.Accounts.AddRange(accountsSet);
            await forumContext.SaveChangesAsync();
        }

        [OneTimeSetUp]
        public async Task SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ForumContext>()
                .UseInMemoryDatabase(databaseName: "account_role_test_database")
                .Options;

            forumContext = new ForumContext(dbContextOptions);

            await PopulateContextSet(forumContext);

            accountRepository = new AccountRepository(forumContext);
        }
        
        [Test]
        public async Task Create_ShouldIncreaseCountByOne()
        {
            var account = new Account("username 7", "password 7", "email 7");

            await accountRepository.Create(account);

            int expectedCount = 7;
            Assert.That(forumContext.Accounts.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task DeleteAccountRoles_ShouldReduceCountByOne()
        {
            string targetUsername = "username 3";

            Expression<Func<Account, bool>> expression =
                acc => acc.Username == targetUsername;

            Account account = accountRepository.FindByCriteria(expression)
                .First();

            await accountRepository.Delete(account);

            int expectedCount = 6;
            Assert.That(forumContext.Accounts.Count(), Is.EqualTo(expectedCount));     
        }

        [Test]
        public async Task UpdateAccountRole_ShouldHaveUpdatedValue()
        {
            string newUsername = "username 100";

            Expression<Func<Account, bool>> expression =
                accRole => accRole.Username == username;

            Account account = accountRepository.FindByCriteria(expression)
                .First();

            account.Username = newUsername;

            await accountRepository.Update(account);

            var result = forumContext.Accounts
                .Where(acc => acc.Username == newUsername)
                .ToList();

            int expectedCount = 1;
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

        [Test]
        public void GetAllAccountRoles_ShouldReturnCorrectAmount()
        {
            var result = accountRepository.FindAll().ToList();

            int expectedCount = 6;
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

        [Test]
        public void FindAccountRolesByRolePriority_ShouldReturnCorrectAmount()
        {
            Expression<Func<Account, bool>> expression =
                acc => acc.Username == username;

            var result = accountRepository.FindByCriteria(expression).ToList();

            int expectedCount = 1;
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

    }
}
