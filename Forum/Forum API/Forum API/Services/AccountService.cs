using Forum_API.Models;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountRoleRepository accountRoleRepository;

        public AccountService(IAccountRepository _accountRepository, IAccountRoleRepository _accountRoleRepository)
        {
            accountRepository = _accountRepository;
            accountRoleRepository = _accountRoleRepository;
        }

        public async Task CreateAccount(Account account, string roleDescription = Constants.defaultRoleDescription)
        {
            Expression<Func<AccountRole, bool>> expression = role => roleDescription.Contains(role.RoleDescription);

            var accountRole = accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (accountRole != null)
            {
                account.AccountRoleId = accountRole.RoleId;
            }

            await accountRepository.Create(account);
        }

        public async Task DeleteAccount(Guid guid)
        {
            Expression<Func<Account, bool>> expression = role => guid.Equals(role.AccountId);

            var account = accountRepository.FindByCriteria(expression).FirstOrDefault();

            if(account != null)
            {
                await accountRepository.Delete(account);
            }
        }

        public async Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<Account, bool>> expression)
        {
            var result = accountRepository.FindByCriteria(expression);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountRepository.FindAll().ToListAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            await accountRepository.Update(account);
        }
    }
}
