using Forum_API.Models;
using Forum_API.Repository.Reposiory_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleContoller : ControllerBase
    {
        private AccountRoleRepository _accountRoleRepository;

        public AccountRoleContoller(AccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        [HttpGet("/create_account_role")]
        public HttpResponseMessage CreateAccountRole(string role_description)
        {
            AccountRole accountRole = new AccountRole();
            accountRole.RoleDescription = role_description;
            _accountRoleRepository.Create(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
