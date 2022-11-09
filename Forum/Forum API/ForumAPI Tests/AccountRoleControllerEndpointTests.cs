using Forum_API.Controllers;
using Forum_API.Repository.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests
{
    internal class AccountRoleControllerEndpointTests
    {
        private Mock<AccountRoleService> mockAccountRoleService;
        private Mock<IAccountRoleRepository> mockRepository;
        private AccountRoleController accountRoleController;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IAccountRoleRepository>();
            mockAccountRoleService = new Mock<AccountRoleService>(mockRepository.Object);
            accountRoleController = new AccountRoleController(mockAccountRoleService.Object);


        }
    }
}
