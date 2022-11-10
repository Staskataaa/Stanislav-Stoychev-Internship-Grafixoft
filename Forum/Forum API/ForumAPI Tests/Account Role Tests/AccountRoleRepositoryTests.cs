using Forum_API.Repository;
using Forum_API.Repository.Reposiory_Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForumAPI_Tests
{
    internal class AccountRoleRepositoryTests
    {
        private DbContextOptions<ForumContext> dbContextOptions;
        private ForumContext forumContext;
        private AccountRoleRepository accountRoleRepository;
        private AccountRole emptyAccountRole;
        private int requestedRolePriority;
        private readonly int newRolePriority = 9;

        private static async Task PopulateContextSet(ForumContext forumContext)
        {
            var accountRolesSet = new[]
            {
                new AccountRole(1, "example role 1"),
                new AccountRole(2, "example role 2"),
                new AccountRole(3, "example role 3"),
                new AccountRole(4, "example role 4"),
                new AccountRole(5, "example role 5"),
                new AccountRole(6, "example role 6")
            };

            forumContext.AccountRoles.AddRange(accountRolesSet);
            await forumContext.SaveChangesAsync();
        }

        [OneTimeSetUp]
        public async Task SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ForumContext>()
                .UseInMemoryDatabase(databaseName: "account_role_test_database")
                .Options;

            forumContext = new ForumContext(dbContextOptions);

            accountRoleRepository = new AccountRoleRepository(forumContext);

            await PopulateContextSet(forumContext);
        }

        [Test]
        public async Task Create_ShouldIncreaseCountByOne()
        {
            var accountRole = new AccountRole(7, "example role 7");

            await accountRoleRepository.Create(accountRole);

            Assert.That(forumContext.AccountRoles.Count(), Is.EqualTo(7));
        }

        [Test]
        public async Task DeleteAllAccountRoles_ReduceCountByOne()
        {
            requestedRolePriority = 6;
            Expression<Func<AccountRole, bool>> expression =
                accRole => accRole.RolePriority == requestedRolePriority;

            AccountRole? accountRole = accountRoleRepository.FindByCriteria(expression)
                .FirstOrDefault() ?? emptyAccountRole;

            await accountRoleRepository.Delete(accountRole);

            Assert.That(forumContext.AccountRoles.Count, Is.EqualTo(6));
        }

        [Test]
        public async Task UpdateAccountRole_ReduceCountByOne()
        {
            requestedRolePriority = 5;
            Expression<Func<AccountRole, bool>> expression =
                accRole => accRole.RolePriority == requestedRolePriority;

            AccountRole accountRole = accountRoleRepository.FindByCriteria(expression)
                .FirstOrDefault() ?? emptyAccountRole;

            accountRole.RolePriority = newRolePriority;

            await accountRoleRepository.Update(accountRole);

            var result = forumContext.AccountRoles
                .Where(accRole => accRole.RolePriority == newRolePriority)
                .ToList();

            Assert.That(result, Has.Count.EqualTo(1));
        }

        [Test]
        public void GetAllAccountRoles_ShouldReturnCorrectAmount()
        {
            var result = accountRoleRepository.FindAll().ToList();

            Assert.That(result, Has.Count.EqualTo(6));
        }

        [Test]
        public void FindAccountRolesByRolePriority_ShouldReturnCorrectAmount()
        {
            requestedRolePriority = 4;
            Expression<Func<AccountRole, bool>> expression =
                accRole => accRole.RolePriority == requestedRolePriority;
            var result = accountRoleRepository.FindByCriteria(expression).ToList();

            Assert.That(result, Has.Count.EqualTo(1));
        }

    }
}
