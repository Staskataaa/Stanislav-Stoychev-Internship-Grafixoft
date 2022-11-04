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
        private readonly IAccountService accountService;
        private ILoggerProvider loggerProvider;

        public AccountController(IAccountService _accountService, ILoggerProvider _loggerProvider)
        {
            accountService = _accountService;
            loggerProvider = _loggerProvider;
        }

        [HttpPost]
        [Route("/account/user")]
        public async Task<HttpResponseMessage> CreateDefaultAccount(AccountRequest accountRequest)
        {
            await accountService.CreateAccount(accountRequest);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("/account/{roleDescription}")]
        public async Task<HttpResponseMessage> CreateAccount(AccountRequest account, string roleDescription)
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
        public async Task<HttpResponseMessage> UpdateAccount(AccountRequest account, Guid accountGuid)
        {
            await accountService.UpdateAccount(account, accountGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/account/{accountPoints}")]
        public async Task<IEnumerable<AccountRequest>> GetAccountWithPoints(int accountPoints)
        {
            loggerProvider.CreateLogger("123").LogInformation("1231231231");
            Expression<Func<Account, bool>> expression = acc => acc.AccountPoints > accountPoints;
            return await accountService.GetAccountByCriteria(expression);
        }

        [HttpGet]
        [Route("/account")]
        public async Task<IEnumerable<AccountRequest>> GetAllAccounts()
        {
            return await accountService.GetAllAccounts();
        }
    }
}
