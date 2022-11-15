﻿using Forum_API.Filters;
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
        public virtual async Task<HttpResponseMessage> CreateAccount(AccountRequest account, 
            string roleDescription = Constants.defaultRoleDescription)
        {
            await _accountService.CreateAccount(account, roleDescription);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("/account/")]
        public virtual async Task<HttpResponseMessage> DeleteAccount(Guid accountGuid)
        {
            await _accountService.DeleteAccount(accountGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("/account/")]
        public virtual async Task<HttpResponseMessage> UpdateAccount(AccountRequest account, Guid accountGuid)
        {
            await _accountService.UpdateAccount(account, accountGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/account/{accountPoints}")]
        public virtual async Task<IEnumerable<Account>> GetAccountWithPoints(int accountPoints)
        {
            Expression<Func<Account, bool>> expression = acc => acc.Points > accountPoints;
            return await _accountService.GetAccountByCriteria(expression);
        }

        [HttpGet]
        [Route("/accounts/")]
        public virtual async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _accountService.GetAllAccounts();
        }
    }
}
