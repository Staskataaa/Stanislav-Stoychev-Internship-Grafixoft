﻿using Forum_API.Exceptions;
using Forum_API.Models;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.RequestObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum_API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountRoleRepository accountRoleRepository;

        public AccountService(IAccountRepository _accountRepository, IAccountRoleRepository _accountRoleRepository)
        {
            accountRepository = _accountRepository;
            accountRoleRepository = _accountRoleRepository;
        }

        public virtual async Task CreateAccount(AccountRequest accountRequest, string roleDescription = Constants.defaultRoleDescription)
        {
            Expression<Func<AccountRole, bool>> expression = role => roleDescription.Contains(role.Description);

            var accountRole = accountRoleRepository.FindByCriteria(expression).FirstOrDefault();

            if (accountRole != null)
            {
                Account account = new Account(accountRequest.Username,
                accountRequest.Password, accountRequest.Email);

                account.RoleId = accountRole.Id;

                await accountRepository.Create(account);
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge); 
            }
        }

        public virtual async Task DeleteAccount(Guid accountGuid)
        {
            Expression<Func<Account, bool>> expression = role => accountGuid == role.Id;

            var account = accountRepository.FindByCriteria(expression).FirstOrDefault();

            if (account != null)
            {
                await accountRepository.Delete(account);
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }

        public virtual async Task<IEnumerable<Account>> GetAccountByCriteria(Expression<Func<Account, bool>> expression)
        {
            var result = accountRepository.FindByCriteria(expression);
            return await result.ToListAsync();
        }

        public virtual async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountRepository.FindAll().ToListAsync();
        }

        public virtual async Task UpdateAccount(AccountRequest accountRequest, Guid accountGuid)
        { 
            Expression<Func<Account, bool>> expression = role => accountGuid.Equals(role.Id);

            var account = accountRepository.FindByCriteria(expression).FirstOrDefault();

            if (account != null)
            {
                account.Email = accountRequest.Email;
                account.Password = accountRequest.Password;
                account.Username = accountRequest.Username;

                await accountRepository.Update(account);
            }
            else
            {
                throw new EntityNotFoundException(ExceptionMessages.entityNotFoundMessge);
            }
        }
    }
}
