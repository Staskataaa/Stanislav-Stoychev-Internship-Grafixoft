using System.Collections.Generic;
using Forum_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum_API.Repository
{
    public partial class ForumContext : DbContext
    {
        public ForumContext()
        {
        }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountRole> AccountRoles { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<React> Reacts { get; set; } = null!;
        public virtual DbSet<ReactValue> ReactValues { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNTS");

                entity.HasIndex(e => e.Username, "UQ__ACCOUNTS__4F5C27E7A1F34271")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__ACCOUNTS__713342DD5E9632ED")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("account_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("account_email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("account_password");

                entity.Property(e => e.Points)
                    .HasColumnName("account_points")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProfilePicPath)
                    .HasColumnType("text")
                    .HasColumnName("account_profile_pic_path");

                entity.Property(e => e.RoleId).HasColumnName("account_role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("account_username");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ACCOUNT___760965CCD994BD26");

                entity.ToTable("ACCOUNT_ROLE");

                entity.HasIndex(e => e.Description, "UQ__ACCOUNT___86671C97B11C7EC4")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("role_description");

                entity.Property(e => e.Priority).HasColumnName("role_priority");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.HasIndex(e => e.ReactId, "UQ__COMMENTS__B76013EF36415F8A")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("comment_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("comment_content");

                entity.Property(e => e.PostId).HasColumnName("comment_post_id");

                entity.Property(e => e.ReactId).HasColumnName("comment_react_id");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POSTS");

                entity.HasIndex(e => e.Title, "UQ__POSTS__6F842368014538B7")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("post_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("post_account_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("post_description");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("post_title");

                entity.Property(e => e.TopicId).HasColumnName("post_topic_id");
            });

            modelBuilder.Entity<React>(entity =>
            {
                entity.ToTable("REACTS");

                entity.Property(e => e.Id)
                    .HasColumnName("react_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("react_account_id");

                entity.Property(e => e.CommentId).HasColumnName("react_comment_id");

                entity.Property(e => e.PostId).HasColumnName("react_post_id");

                entity.Property(e => e.ValueId).HasColumnName("react_value");
            });

            modelBuilder.Entity<ReactValue>(entity =>
            {
                entity.ToTable("REACT_VALUE");

                entity.Property(e => e.Id)
                    .HasColumnName("react_value_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .HasColumnName("react_description");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("TOPICS");

                entity.HasIndex(e => e.Name, "UQ__TOPICS__54BAE5EC8EC4A43C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("topic_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("topic_description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("topic_name");

                entity.Property(e => e.Owner).HasColumnName("topic_owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
