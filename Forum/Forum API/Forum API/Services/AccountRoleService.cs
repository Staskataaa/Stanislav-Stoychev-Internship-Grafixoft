using Forum_API.Models;
using Forum_API.Repository.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forum_API.Services
{
    public class AccountRoleService : IAccountRoleService
    {

        private readonly IAccountRoleRepository accountRoleRepository;

        public AccountRoleService(IAccountRoleRepository accountRoleRepository)
        {
            this.accountRoleRepository = accountRoleRepository;
        }

        public async Task CreateAccountRole(AccountRole accountRole)
        {
            await accountRoleRepository.Create(accountRole);
            await accountRoleRepository.SaveChanges();
        }

        public async Task DeleteAccountRole(AccountRole accountRole)
        {
            await accountRoleRepository.Delete(accountRole);
            await accountRoleRepository.SaveChanges();
        }

        public async Task<IEnumerable<AccountRole>> GetAccountRoleByPriority(int rolePriopity)
        {
            return await accountRoleRepository.Where(accountRole =>
            accountRole.RolePriority == rolePriopity).ToListAsync();
        }

        public async Task<IEnumerable<AccountRole>> GetAllAccountRoles()
        {
            return await accountRoleRepository.FindAll().ToListAsync();
        }

        public async Task UpdateAccountRole(AccountRole accountRole)
        {
            await accountRoleRepository.Update(accountRole);
            await accountRoleRepository.SaveChanges();
        }
    }
}
