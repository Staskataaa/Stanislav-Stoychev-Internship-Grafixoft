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
            AccountRole accountRole = new AccountRole(accountRoleRequest.Priority,
                accountRoleRequest.Description);

            await _accountRoleRepository.Create(accountRole);
        }

        public virtual async Task DeleteAccountRole(Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.Id == accountRoleGuid;

            var account = _accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (account != null)
            {
                await _accountRoleRepository.Delete(account);
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
            return await resultSet.ToListAsync();
        }

        public virtual async Task UpdateAccountRole(AccountRoleRequest accountRoleRequest, Guid accountRoleGuid)
        {
            Expression<Func<AccountRole, bool>> expression = role => role.Id == accountRoleGuid;

            var accountRole = _accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (accountRole != null)
            {
                accountRole.Priority = accountRoleRequest.Priority;
                accountRole.Description = accountRoleRequest.Description;

                await _accountRoleRepository.Update(accountRole);
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }
    }
}
