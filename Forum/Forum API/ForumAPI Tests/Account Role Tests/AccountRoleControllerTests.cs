using Forum_API.Controllers;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
using System.Linq.Expressions;
using System.Net;

namespace ForumAPI_Tests
{
    internal class AccountRoleControllerTests
    {
        private Mock<AccountRoleService> mockAccountRoleService;
        private Mock<IAccountRoleRepository> mockRepository;
        private AccountRoleController accountRoleController;
        private AccountRole accountRoleOne, accountRoleTwo;
        private ICollection<AccountRole> accountRoles;
        private readonly Expression<Func<AccountRole, bool>> expression =
            role => role.RoleId == Guid.Empty;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IAccountRoleRepository>();
            mockAccountRoleService = new Mock<AccountRoleService>(mockRepository.Object);
            accountRoleController = new AccountRoleController(mockAccountRoleService.Object);

            accountRoleOne = new AccountRole(2, "test role description");

            accountRoleTwo = new AccountRole(3, "test role description 2");

            accountRoles = new List<AccountRole>
            {
                accountRoleOne,
                accountRoleTwo
            };

            mockAccountRoleService.Setup(mock => mock.CreateAccountRole(It.IsAny<AccountRoleRequest>()))
                .Verifiable();

            mockAccountRoleService.Setup(mock => mock.DeleteAccountRole(It.IsAny<Guid>()))
                .Verifiable();

            mockAccountRoleService.Setup(mock => mock.UpdateAccountRole(It.IsAny<AccountRoleRequest>(), It.IsAny<Guid>()))
                .Verifiable();

            mockAccountRoleService.Setup(mock => mock.GetAllAccountRoles())
                .Returns(Task.FromResult(accountRoles.AsEnumerable()))
                .Verifiable();

            mockAccountRoleService.Setup(mock => mock.GetAccountRoleByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()))
                .Returns(Task.FromResult(accountRoles.AsQueryable().Where(expression).AsEnumerable()))
                .Verifiable();
        }

        [Test]
        public async Task CreateAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.CreateAccountRole(It.IsAny<AccountRoleRequest>());

            mockAccountRoleService.Verify(mock => mock.CreateAccountRole(It.IsAny<AccountRoleRequest>()), Times.Once);
            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task DeleteAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.DeleteAccountRole(It.IsAny<Guid>());

            mockAccountRoleService.Verify(mock => mock.DeleteAccountRole(It.IsAny<Guid>()), Times.Once);

            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task UpdateAccountRole_ShouldReturnStatusOK()
        {
            var expected = new HttpResponseMessage(HttpStatusCode.OK);

            var result = await accountRoleController.UpdateAccountRole(It.IsAny<AccountRoleRequest>(), It.IsAny<Guid>());

            mockAccountRoleService.Verify(mock => 
                mock.UpdateAccountRole(It.IsAny<AccountRoleRequest>(), It.IsAny<Guid>()), Times.Once);

            Assert.That(result.StatusCode, Is.EqualTo(expected.StatusCode));
        }

        [Test]
        public async Task GetAccountRoleByRolePriority_ShouldReturnAccountRole()
        {
            var excepedCount = accountRoles.Count;

            var result = await accountRoleController.GetAccountRoleByRoleId(It.IsAny<Guid>());

            mockAccountRoleService.Verify(mock => mock
                .GetAccountRoleByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()), Times.Once);

            Assert.That(result.Count(), Is.EqualTo(excepedCount));
        }

        [Test]
        public async Task GetAllAccountRoles_ShouldReturnAll()
        {
            var expectedCount = accountRoles.Count;

            var result = await accountRoleController.GetAllAccountRoles();

            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }
    }
}
