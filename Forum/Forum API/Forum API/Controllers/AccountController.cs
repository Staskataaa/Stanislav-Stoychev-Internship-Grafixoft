using Forum_API.Models;
using Forum_API.RequestObjects;
using Forum_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Forum_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("/account/")]
        public async Task<HttpResponseMessage> CreateAccount(AccountRequest account, 
            string roleDescription = Constants.defaultRoleDescription)
        {
            await _accountService.CreateAccount(account, roleDescription);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("/account/")]
        public async Task<HttpResponseMessage> DeleteAccount(Guid accountGuid)
        {
            await _accountService.DeleteAccount(accountGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("/account/")]
        public async Task<HttpResponseMessage> UpdateAccount(AccountRequest account, Guid accountGuid)
        {
            await _accountService.UpdateAccount(account, accountGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/account/{accountPoints}")]
        public async Task<IEnumerable<AccountRequest>> GetAccountWithPoints(int accountPoints)
        {
            Expression<Func<Account, bool>> expression = acc => acc.AccountPoints > accountPoints;
            return await _accountService.GetAccountByCriteria(expression);
        }

        [HttpGet]
        [Route("/accounts/")]
        public async Task<IEnumerable<AccountRequest>> GetAllAccounts()
        {
 
            return await _accountService.GetAllAccounts();
        }
    }
}
