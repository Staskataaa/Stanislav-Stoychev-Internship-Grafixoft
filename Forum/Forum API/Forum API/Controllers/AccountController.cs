using Forum_API.Models;
using Forum_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Forum_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        [Route("/account/user")]
        public async Task<HttpResponseMessage> CreateDefaultAccount(Account account)
        {
            await accountService.CreateAccount(account);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("/account/{roleDescription}")]
        public async Task<HttpResponseMessage> CreateAccount(Account account, string roleDescription)
        {
            await accountService.CreateAccount(account, roleDescription);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("/account/{guid}")]
        public async Task<HttpResponseMessage> DeleteAccount(Guid guid)
        {
            await accountService.DeleteAccount(guid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("/account/update")]
        public async Task<HttpResponseMessage> UpdateAccount(Account account)
        {
            await accountService.UpdateAccount(account);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/account/{accountPoints}")]
        public async Task<IEnumerable<Account>> GetAccountWithPoints(int accountPoints)
        {
            Expression<Func<Account, bool>> expression = acc => acc.AccountPoints > accountPoints;
            return await accountService.GetAccountByCriteria(expression);
        }

        [HttpGet]
        [Route("/account")]
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountService.GetAllAccounts();
        }
    }
}
