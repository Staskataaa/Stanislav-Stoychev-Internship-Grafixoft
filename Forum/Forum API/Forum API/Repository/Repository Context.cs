using Microsoft.EntityFrameworkCore;
using Forum_API.Models;

namespace Forum_API.Repository
{
    public class Repository_Context : DbContext
    { 
        //is it really necessary to provide all access to all models
        public Repository_Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account>? Accounts { get; set; }

        public DbSet<Comment>? Comments { get; set; }

        public DbSet<Post>? Posts { get; set; }

        public DbSet<React>? React { get; set; }

        public DbSet<Topic>? Topic { get; set; }

    }
}
