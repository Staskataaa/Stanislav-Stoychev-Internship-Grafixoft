using Forum_API.Models;
using Forum_API.Repository.Repository_Interfaces;

namespace Forum_API.Repository.Reposiory_Models
{
    public class AccountRoleRepository: BaseRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(ForumContext repository_Context)
            : base(repository_Context)
        {
        }

        public AccountRole GetByGuid(Guid guid)
        {
            return Repository_Context.Set<AccountRole>()
                .Select(s => s)
                .Where(accountRole => accountRole.RoleId == guid)
                .First();
        }
    }
}
