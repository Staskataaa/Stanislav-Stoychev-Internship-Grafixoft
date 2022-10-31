using Forum_API.Models;
using Forum_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountRoleService;

        public AccountController(IAccountService _accountRoleService)
        {
            accountRoleService = _accountRoleService;
        }

        [HttpPost]
        [Route("/account")]
        public async Task<HttpResponseMessage> CreateAccount(Account account, string roleDescription)
        {
            account.AccountRoleId = 

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
