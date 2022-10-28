using Forum_API.Models;
using Forum_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Forum_API.Controllers
{
    
    [ApiController("api/[controller]")]
    public class AccountRoleController : ApiController
    {
        private readonly IAccountRoleService accountRoleService;

        public AccountRoleController(IAccountRoleService _accountRoleService)
        {
            accountRoleService = _accountRoleService;
        }

        /*[System.Web.Http.HttpPost]
        [System.Web.Http.Route("/accountRole")]
        
        public async Task<HttpResponseMessage> CreateAccountRole(AccountRole accountRole)
        {

            accountRoleService.Test();
                await accountRoleService.CreateAccountRole(accountRole);
                return new HttpResponseMessage(HttpStatusCode.OK);
            
        }

        [HttpPost]
        [Route("/test")]

        public int Test()
        {
            return accountRoleService.Test();
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
        }*/

        [Filters.MyExceptionFilter]
        [System.Web.Http.HttpDelete()]
        [System.Web.Http.Route("/accountRole/remove")]
        public async Task<HttpResponseMessage> DeleteAccountRoles(AccountRole accountRole)
        {       
            throw new Exception();
            await accountRoleService.DeleteAccountRole(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /*
        [HttpPut]
        [Route("/accountRole/update")]
        public async Task<HttpResponseMessage> UpdateAccountRoles(AccountRole accountRole)
        {
            await accountRoleService.UpdateAccountRole(accountRole);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }*/
    }
}
