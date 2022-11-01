using Forum_API.Repository.Repository_Interfaces;
using Moq;
using System.Linq.Expressions;


namespace ForumAPI_Tests
{
    internal class AccountRoleServiceTest
    {
        private Mock<IAccountRoleRepository> mockRepository;
        private AccountRole accountRoleOne, accountRoleTwo;
        private static readonly int rolePriority = 1;
        private AccountRoleService accountRoleService;
        private ICollection<AccountRole> accountRoles;
        private readonly Expression<Func<AccountRole, bool>> expression = 
            role => role.RolePriority == rolePriority;

        [SetUp]
        public void SetUp()
        {
            string roleDescription = "Test Role";

            accountRoleOne = new AccountRole
            {
                RolePriority = rolePriority,
                RoleDescription = roleDescription,
            };

            accountRoleTwo = new AccountRole
            {
                RolePriority = 2,
                RoleDescription = roleDescription,
            };

            accountRoles = new List<AccountRole>
            {
                accountRoleOne,
                accountRoleTwo,
            };

            mockRepository = new Mock<IAccountRoleRepository>();

            mockRepository.Setup(mock => mock.Create(accountRoleOne)).Verifiable();
            mockRepository.Setup(mock => mock.Update(accountRoleOne)).Verifiable();
            mockRepository.Setup(mock => mock.Delete(accountRoleOne)).Verifiable();
            mockRepository.Setup(mock => mock.SaveChanges()).Verifiable();

            mockRepository.Setup(mock => mock.FindAll()).Returns(accountRoles.AsAsyncQueryable());
            mockRepository.Setup(mock => mock.FindByCriteria(expression)).Returns(accountRoles.AsAsyncQueryable().Where(expression));

            accountRoleService = new AccountRoleService(mockRepository.Object);
        }

        [Test]
        public async Task CreateAccountRole_ShouldCallCreateAndSaveChanges()
        {
            await accountRoleService.CreateAccountRole(accountRoleOne);
            mockRepository.Verify(mock => mock.Create(accountRoleOne), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task DeleteAccountRole_ShouldCallDeleteAndSaveChanges()
        {
            await accountRoleService.DeleteAccountRole(accountRoleOne);
            mockRepository.Verify(mock => mock.Delete(accountRoleOne), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task UpdateAccountRole_ShouldCallUpdateAndSaveChanges()
        {
            await accountRoleService.UpdateAccountRole(accountRoleOne);
            mockRepository.Verify(mock => mock.Update(accountRoleOne), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task GetAllAccountRoles_ShouldCallFindAll()
        {
            var result = await accountRoleService.GetAllAccountRoles();
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetAccountRolesByRolePriority_ShouldCallWhere()
        {
            var result = await accountRoleService.GetAccountRoleByCriteria(expression);
            Assert.AreEqual(1, result.Count());
        }
    }
}