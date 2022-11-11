using Forum_API.Models;
using Forum_API.RequestObjects;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public interface IAccountService
    {
        public Task CreateAccount(AccountRequest accountRole, string roleDescription = "default user");

        public Task DeleteAccount(Guid guid);

        public Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<Account, bool>> expression);

        public Task<IEnumerable<Account>> GetAllAccounts();

        public Task UpdateAccount(AccountRequest accountRole, Guid accountGuid);
    }
}
