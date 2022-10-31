using Forum_API.Models;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public interface IAccountRoleService
    {
        public Task CreateAccountRole(AccountRole accountRole);

        public Task DeleteAccountRole(AccountRole accountRole);

        public Task<IEnumerable<AccountRole>> GetAccountRoleByCriteria(Expression<Func<AccountRole, bool>> expression);

        public Task<IEnumerable<AccountRole>> GetAllAccountRoles();

        public Task UpdateAccountRole(AccountRole accountRole);

    }
}
