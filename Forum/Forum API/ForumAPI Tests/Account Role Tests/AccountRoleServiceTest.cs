using Forum_API.Exceptions;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
using System.Linq.Expressions;

namespace ForumAPI_Tests
{
    internal class AccountRoleServiceTest
    {
        private Mock<IAccountRoleRepository> mockRepository;
        private AccountRoleService accountRoleService;
        private AccountRole accountRoleOne, accountRoleTwo;
        private AccountRoleRequest accountRoleRequestOne;
        private List<AccountRole> accountRoles;
        private Expression<Func<AccountRole, bool>> expression;
        private readonly int requestedRolePriority = 1;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IAccountRoleRepository>();

            accountRoleOne = new AccountRole(1, "exampleDescription");
            accountRoleTwo = new AccountRole(2, "exampleDescription 2");
            accountRoleRequestOne = new AccountRoleRequest();

            expression = role => role.RolePriority == requestedRolePriority;

            accountRoles = new List<AccountRole>
            {
                accountRoleOne,
                accountRoleTwo
            };

            mockRepository.Setup(mock => mock.Create(It.IsAny<AccountRole>())).Verifiable();
            mockRepository.Setup(mock => mock.Update(It.IsAny<AccountRole>())).Verifiable();
            mockRepository.Setup(mock => mock.Delete(It.IsAny<AccountRole>())).Verifiable();

            mockRepository.Setup(mock => mock.SaveChanges()).Verifiable();

            mockRepository.Setup(mock => mock.FindAll()).Returns(accountRoles.AsAsyncQueryable());

            mockRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()))
                .Returns(accountRoles.AsAsyncQueryable().Where(expression));

            accountRoleService = new AccountRoleService(mockRepository.Object);
        }

        [Test]
        public async Task CreateAccountRole_ShouldCallCreateAndSaveChanges()
        {
            await accountRoleService.CreateAccountRole(accountRoleRequestOne);

            mockRepository.Verify(mock => mock.Create(It.IsAny<AccountRole>()), Times.Once);
        }

        [Test]
        public async Task DeleteAccountRole_ShouldCallDeleteAndSaveChanges()
        {
            await accountRoleService.DeleteAccountRole(accountRoleOne.RoleId);

            mockRepository.Verify(mock => mock.Delete(It.IsAny<AccountRole>()), Times.Once);
        }

        [Test]
        public async Task GetAllAccountRoles_ShouldCallFindAll()
        {
            var result = await accountRoleService.GetAllAccountRoles();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAccountRolesByRolePriority_ShouldCallWhere()
        {
            var result = await accountRoleService.GetAccountRoleByCriteria(expression);

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateAccountRole_ShouldCallUpdate()
        {
            await accountRoleService.UpdateAccountRole(accountRoleRequestOne, accountRoleOne.RoleId);

            mockRepository.Verify(mock => mock.Update(It.IsAny<AccountRole>()), Times.Once);
        }

        [Test]
        public void UpdateAccountRole_FindByCriteriaShouldThrowException()
        {
            mockRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()))
                .Throws<EntityNotFoundException>();

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountRoleService
            .UpdateAccountRole(It.IsAny<AccountRole>(), It.IsAny<Guid>()));
        }

        [Test]
        public void DeleteAccountRole_FindByCriteriaShouldThrowException()
        {
            mockRepository.Setup(mock => mock.FindByCriteria(It.IsAny<Expression<Func<AccountRole, bool>>>()))
                .Throws<EntityNotFoundException>();

            Assert.ThrowsAsync<EntityNotFoundException>(() => accountRoleService
            .DeleteAccountRole(It.IsAny<Guid>()));
        }
    }
}