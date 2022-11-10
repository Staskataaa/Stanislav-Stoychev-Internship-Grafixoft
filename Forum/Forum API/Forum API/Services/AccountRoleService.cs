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

        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleService(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        public virtual async Task CreateAccountRole(AccountRoleRequest accountRoleRequest)
        {
            AccountRole accountRole = new AccountRole(accountRoleRequest.RolePriority,
                accountRoleRequest.RoleDescription);

            await _accountRoleRepository.Create(accountRole);
            await _accountRoleRepository.SaveChanges();
        }

        public virtual async Task DeleteAccountRole(Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;

            var account = _accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (account != null)
            {
                await _accountRoleRepository.Delete(account);
                await _accountRoleRepository.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }

        public virtual async Task<IEnumerable<AccountRole>> GetAccountRoleByCriteria(Expression<Func<AccountRole, bool>> expression) 
        {
            var resultSet = _accountRoleRepository.FindByCriteria(expression);
            return await resultSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<AccountRole>> GetAllAccountRoles()
        {
            var resultSet = _accountRoleRepository.FindAll();
            var type = resultSet.GetType();
            return await resultSet.ToListAsync();
        }

        public virtual async Task UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.RoleId == accountRoleGuid;

            var accountRole = _accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (accountRole != null)
            {
                accountRole.RolePriority = accountRoleRequest.RolePriority;
                accountRole.RoleDescription = accountRoleRequest.RoleDescription;

                await _accountRoleRepository.Update(accountRole);
                await _accountRoleRepository.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }
    }
}
