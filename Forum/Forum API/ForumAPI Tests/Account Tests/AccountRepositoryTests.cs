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
        private readonly Account emptyAccount;
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

            Assert.That(forumContext.Accounts.Count(), Is.EqualTo(7));
        }

        [Test]
        public async Task DeleteAllAccountRoles_ReduceCountByOne()
        {
            string targetUsername = "username 3";
            Expression<Func<Account, bool>> expression =
                acc => acc.AccountUsername == targetUsername;

            Account? account = accountRepository.FindByCriteria(expression)
                .FirstOrDefault() ?? emptyAccount;

            await accountRepository.Delete(account);

            Assert.That(forumContext.Accounts.Count, Is.EqualTo(6));
        }

        [Test]
        public async Task UpdateAccountRole_ReduceCountByOne()
        {
            string newUsername = "username 100";

            Expression<Func<Account, bool>> expression =
                accRole => accRole.AccountUsername == username;

            Account account = accountRepository.FindByCriteria(expression)
                .FirstOrDefault() ?? emptyAccount;

            account.AccountUsername = newUsername;

            await accountRepository.Update(account);

            var result = forumContext.Accounts
                .Where(acc => acc.AccountUsername == newUsername)
                .ToList();

            Assert.That(result, Has.Count.EqualTo(1));
        }

        [Test]
        public void GetAllAccountRoles_ShouldReturnCorrectAmount()
        {
            var result = accountRepository.FindAll().ToList();

            Assert.That(result, Has.Count.EqualTo(6));
        }

        [Test]
        public void FindAccountRolesByRolePriority_ShouldReturnCorrectAmount()
        {
            Expression<Func<Account, bool>> expression =
                acc => acc.AccountUsername == username;

            var result = accountRepository.FindByCriteria(expression).ToList();

            Assert.That(result, Has.Count.EqualTo(1));
        }

    }
}
