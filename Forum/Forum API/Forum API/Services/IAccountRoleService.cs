using Forum_API.Models;
using Forum_API.RequestObjects;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public interface IAccountRoleService
    {
        public Task CreateAccountRole(AccountRoleRequest accountRole);

        public Task DeleteAccountRole(Guid accountGuid);

        public Task<IEnumerable<AccountRole>> GetAccountRoleByCriteria(Expression<Func<AccountRole, bool>> expression);

        public Task<IEnumerable<AccountRole>> GetAllAccountRoles();

        public Task UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid);

    }
}
