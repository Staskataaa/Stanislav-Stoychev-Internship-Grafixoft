using Forum_API.Filters;
using Forum_API.Models;
using Forum_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Forum_API.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleService accountRoleService;

        public AccountRoleController(IAccountRoleService _accountRoleService)
        {
            accountRoleService = _accountRoleService;
        }

        [HttpPost]
        [Route("/accountRole")]
        public async Task<HttpResponseMessage> CreateAccountRole(AccountRole accountRole)
        { 
            await accountRoleService.CreateAccountRole(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK); 
        }

        [HttpGet]
        [Route("/accountRole/{rolePriority}")]
        public async Task<IEnumerable<AccountRole>> GetAccountRoleByRolePriority(int rolePriority)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RolePriority == rolePriority;
            var result = await accountRoleService.GetAccountRoleByCriteria(expression);
            return result;
        }

        [HttpGet]
        [Route("/accountRole/all")]
        public async Task<IEnumerable<AccountRole>> GetAllAccountRoles() 
        {
            var result = await accountRoleService.GetAllAccountRoles();
            return result;
        }

        [HttpDelete]
        [Route("/accountRole/remove")]
        public async Task<HttpResponseMessage> DeleteAccountRoles(AccountRole accountRole)
        {
            throw new StackOverflowException("123123");
            await accountRoleService.DeleteAccountRole(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        [HttpPut]
        [Route("/accountRole/update")]
        public async Task<HttpResponseMessage> UpdateAccountRoles(AccountRole accountRole)
        {
            await accountRoleService.UpdateAccountRole(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
