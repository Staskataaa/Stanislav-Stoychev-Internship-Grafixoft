using Forum_API;
using Forum_API.Controllers;
using Forum_API.Repository.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests
{
    internal class AccountRoleControllerTest
    {
        /*AccountRoleController accountRoleController;
        Mock<AccountRoleService> mockAccountRoleService;
        IAccountRoleRepository accountRoleRepository;
        AccountRole accountRole;
        AccountRole accountRole2;
        private static readonly int rolePriority = 2;
        ICollection<AccountRole> accountRoles;
        Expression<Func<AccountRole, bool>> expression =
            role => role.RolePriority == rolePriority;

        [SetUp]
        public void SetUp()
        {
            mockAccountRoleService = new Mock<AccountRoleService>(accountRoleRepository);
            accountRoleController = new AccountRoleController(mockAccountRoleService.Object);

            accountRole = new AccountRole
            {
                RoleDescription = "test role description",
                RolePriority = 2,
            };

            accountRole2 = new AccountRole
            {
                RoleDescription = "test role description 2 ",
                RolePriority = 3,
            };

            accountRoles = new List<AccountRole>();

            accountRoles.Add(accountRole);
            accountRoles.Add(accountRole2);

            mockAccountRoleService.Setup(mock => mock.CreateAccountRole(accountRole)).Verifiable();
            mockAccountRoleService.Setup(mock => mock.DeleteAccountRole(accountRole)).Verifiable();
            mockAccountRoleService.Setup(mock => mock.UpdateAccountRole(accountRole)).Verifiable();

            mockAccountRoleService.Setup(mock => mock.GetAllAccountRoles())
                .Returns(Task.FromResult(accountRoles.AsEnumerable())).Verifiable();

            mockAccountRoleService.Setup(mock => mock.GetAccountRoleByCriteria(expression)).
                Returns(Task.FromResult(accountRoles.AsQueryable().Where(expression).AsEnumerable())).Verifiable();
        }

        [Test]
        public async Task CreateAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.CreateAccountRole(accountRole);

            mockAccountRoleService.Verify(mock => mock.CreateAccountRole(accountRole), Times.Once);
            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task DeleteAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.DeleteAccountRole(accountRole);

            mockAccountRoleService.Verify(mock => mock.DeleteAccountRole(accountRole), Times.Once);
            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task UpdateAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.UpdateAccountRole(accountRole);

            mockAccountRoleService.Verify(mock => mock.UpdateAccountRole(accountRole), Times.Once);
            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task GetAccountRoleByRolePriority_ShouldReturnAccountRole()
        {
            var expected = new List<AccountRole>
            {
                accountRole,
            };

            var result = await accountRoleController.GetAccountRoleByRolePriority(rolePriority);

            mockAccountRoleService.Verify(mock => mock.GetAccountRoleByCriteria(expression), Times.Once);

            Assert.That(result.Count(), Is.EqualTo(expected.Count));
        }

        [Test]
        public async Task GetAllAccountRoles_ShouldReturnAll()
        {
            var expectedCount = accountRoles.Count;

            var result = await accountRoleController.GetAllAccountRoles();

            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }
    */}
}
