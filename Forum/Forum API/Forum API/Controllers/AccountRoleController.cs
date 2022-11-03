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
    public class AccountRoleController : DefaultController
    {
        private readonly IAccountRoleService accountRoleService;

        public AccountRoleController(IAccountRoleService _accountRoleService, ILogger<DefaultController> logger) 
            : base(logger)
        {
            accountRoleService = _accountRoleService;
        }

        [HttpPost]
        [Route("/accountRole")]
        public async Task<HttpResponseMessage> CreateAccountRole(AccountRoleRequest accountRoleRequest)
        { 
            await accountRoleService.CreateAccountRole(accountRoleRequest);
            return new HttpResponseMessage(HttpStatusCode.OK); 
        }

        [HttpGet]
        [Route("/accountRole")]
        public async Task<IEnumerable<AccountRole>> GetAccountRoleByRoleId(Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;
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
        public async Task<HttpResponseMessage> DeleteAccountRole(Guid accountRoleGuid)
        {
            await accountRoleService.DeleteAccountRole(accountRoleGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        [HttpPut]
        [Route("/accountRole/update")]
        public async Task<HttpResponseMessage> UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid)
        {
            await accountRoleService.UpdateAccountRole(accountRoleRequest, accountRoleGuid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
