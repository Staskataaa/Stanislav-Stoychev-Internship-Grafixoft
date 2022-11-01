using Forum_API.Models;
using Forum_API.Repository.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<AccountRole>> GetAccountRoleByCriteria(Expression<Func<AccountRole, bool>> expression) 
        {
            var resultSet = accountRoleRepository.FindByCriteria(expression);
            return await resultSet.ToListAsync();
        }

        public async Task<IEnumerable<AccountRole>> GetAllAccountRoles()
        {
            var resultSet = accountRoleRepository.FindAll();
            return await resultSet.ToListAsync();
        }

        public async Task UpdateAccountRole(AccountRole accountRole)
        {
            await accountRoleRepository.Update(accountRole);
            await accountRoleRepository.SaveChanges();
        }
    }
}
