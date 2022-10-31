using Forum_API.Models;
using Forum_API.Repository.Reposiory_Models;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        public async Task CreateAccount(Account accountRole)
        {
            await accountRepository.Create(accountRole);
            await accountRepository.SaveChanges();
        }

        public Task DeleteAccount(Account accountRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<AccountRole, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(Account accountRole)
        {
            throw new NotImplementedException();
        }
    }
}
