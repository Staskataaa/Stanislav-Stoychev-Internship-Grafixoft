using Forum_API.Models;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public interface IAccountService
    {
        public Task CreateAccount(Account accountRole, string roleDescription = "default user");

        public Task DeleteAccount(Guid guid);

        public Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<Account, bool>> expression);

        public Task<IEnumerable<Account>> GetAllAccounts();

        public Task UpdateAccount(Account accountRole);
    }
}
