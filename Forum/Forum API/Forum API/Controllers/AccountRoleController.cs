using Forum_API.Models;
using Forum_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<HttpResponseMessage> GetAccountRoleByRolePriority(int rolePriority)
        {
            await accountRoleService.GetAccountRoleByPriority(rolePriority);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/accountRole/all")]
        public async Task<HttpResponseMessage> GetAllAccountRoles(int rolePriority) 
        {
            await accountRoleService.GetAllAccountRoles();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("/accountRole/remove")]
        public async Task<HttpResponseMessage> DeleteAccountRoles(AccountRole accountRole)
        {
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
