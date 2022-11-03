using Forum_API.Exceptions;
using Forum_API.Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
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

        public virtual async Task CreateAccountRole(AccountRoleRequest accountRoleRequest)
        {
            AccountRole accountRole = new AccountRole(accountRoleRequest.RolePriority,
                accountRoleRequest.RoleDescription);

            await accountRoleRepository.Create(accountRole);
            await accountRoleRepository.SaveChanges();
        }

        public virtual async Task DeleteAccountRole(Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;

            var account = accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (account != null)
            {
                await accountRoleRepository.Delete(account);
                await accountRoleRepository.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }

        public virtual async Task<IEnumerable<AccountRole>> GetAccountRoleByCriteria(Expression<Func<AccountRole, bool>> expression) 
        {
            var resultSet = accountRoleRepository.FindByCriteria(expression);
            return await resultSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<AccountRole>> GetAllAccountRoles()
        {
            var resultSet = accountRoleRepository.FindAll();
            return await resultSet.ToListAsync();
        }

        public virtual async Task UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;

            var accountRole = accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (accountRole != null)
            {
                accountRole.RolePriority = accountRoleRequest.RolePriority;
                accountRole.RoleDescription = accountRoleRequest.RoleDescription;

                await accountRoleRepository.Update(accountRole);
                await accountRoleRepository.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }
    }
}
