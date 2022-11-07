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
    public class AccountRoleController : Controller
    {
        private readonly IAccountRoleService _accountRoleService;

        public AccountRoleController(IAccountRoleService accountRoleService)
        {
            _accountRoleService = accountRoleService;
        }

        [HttpPost]
        [Route("/accountRole")]
        public async Task<HttpResponseMessage> CreateAccountRole(AccountRoleRequest accountRoleRequest)
        { 
            await _accountRoleService.CreateAccountRole(accountRoleRequest);
            return new HttpResponseMessage(HttpStatusCode.OK); 
        }

        [HttpGet]
        [Route("/accountRole")]
        public async Task<IEnumerable<AccountRole>> GetAccountRoleByRoleId(Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;
            var result = await _accountRoleService.GetAccountRoleByCriteria(expression);
            return result;
        }

        [HttpGet]
        [Route("/accountRoles/")]
        public async Task<IEnumerable<AccountRole>> GetAllAccountRoles() 
        {
            var result = await _accountRoleService.GetAllAccountRoles();
            return result;
        }

        [HttpDelete]
        [Route("/accountRole")]
        public async Task<HttpResponseMessage> DeleteAccountRole(Guid accountRoleGuid)
        {
            await _accountRoleService.DeleteAccountRole(accountRoleGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        [HttpPut]
        [Route("/accountRole")]
        public async Task<HttpResponseMessage> UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid)
        {
            await _accountRoleService.UpdateAccountRole(accountRoleRequest, accountRoleGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
