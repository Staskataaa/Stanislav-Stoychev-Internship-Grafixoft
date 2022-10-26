using Forum_API.Models;

namespace Forum_API.Services
{
    public interface IAccountRoleService
    {
        public Task CreateAccountRole(AccountRole accountRole);

        public Task DeleteAccountRole(AccountRole accountRole);

        public Task<IEnumerable<AccountRole>> GetAccountRoleByPriority(int rolePriopity);

        public Task<IEnumerable<AccountRole>> GetAllAccountRoles();

        public Task UpdateAccountRole(AccountRole accountRole);
    }
}
