using Forum_API.Models;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public interface IAccountService
    {
        public Task CreateAccount(Account accountRole);

        public Task DeleteAccount(Account accountRole);

        public Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<AccountRole, bool>> expression);

        public Task<IEnumerable<Account>> GetAllAccounts();

        public Task UpdateAccount(Account accountRole);
    }
}
