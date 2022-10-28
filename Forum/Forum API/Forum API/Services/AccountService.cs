using Forum_API.Models;

namespace Forum_API.Services
{
    public class AccountService
    {
        private readonly IAccountService accountService;

        public AccountService(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        /*public async Task CreateAccount(Account account)*/

    }
}
