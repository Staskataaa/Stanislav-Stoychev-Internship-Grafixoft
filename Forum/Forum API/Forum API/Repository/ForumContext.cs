using System;
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

                entity.HasIndex(e => e.AccountUsername, "UQ__ACCOUNTS__4F5C27E7A1F34271")
                    .IsUnique();

                entity.HasIndex(e => e.AccountEmail, "UQ__ACCOUNTS__713342DD5E9632ED")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountEmail)
                    .HasMaxLength(255)
                    .HasColumnName("account_email");

                entity.Property(e => e.AccountPassword)
                    .HasMaxLength(255)
                    .HasColumnName("account_password");

                entity.Property(e => e.AccountPoints)
                    .HasColumnName("account_points")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountProfilePicPath)
                    .HasColumnType("text")
                    .HasColumnName("account_profile_pic_path");

                entity.Property(e => e.AccountRoleId).HasColumnName("account_role_id");

                entity.Property(e => e.AccountUsername)
                    .HasMaxLength(255)
                    .HasColumnName("account_username");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__ACCOUNT___760965CCD994BD26");

                entity.ToTable("ACCOUNT_ROLE");

                entity.HasIndex(e => e.RoleDescription, "UQ__ACCOUNT___86671C97B11C7EC4")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(255)
                    .HasColumnName("role_description");

                entity.Property(e => e.RolePriority).HasColumnName("role_priority");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.HasIndex(e => e.CommentReactId, "UQ__COMMENTS__B76013EF36415F8A")
                    .IsUnique();

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CommentContent)
                    .HasMaxLength(255)
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentPostId).HasColumnName("comment_post_id");

                entity.Property(e => e.CommentReactId).HasColumnName("comment_react_id");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POSTS");

                entity.HasIndex(e => e.PostTitle, "UQ__POSTS__6F842368014538B7")
                    .IsUnique();

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PostAccountId).HasColumnName("post_account_id");

                entity.Property(e => e.PostDescription)
                    .HasColumnType("text")
                    .HasColumnName("post_description");

                entity.Property(e => e.PostTitle)
                    .HasMaxLength(255)
                    .HasColumnName("post_title");

                entity.Property(e => e.PostTopicId).HasColumnName("post_topic_id");
            });

            modelBuilder.Entity<React>(entity =>
            {
                entity.ToTable("REACTS");

                entity.Property(e => e.ReactId)
                    .HasColumnName("react_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ReactAccountId).HasColumnName("react_account_id");

                entity.Property(e => e.ReactCommentId).HasColumnName("react_comment_id");

                entity.Property(e => e.ReactPostId).HasColumnName("react_post_id");

                entity.Property(e => e.ReactValueId).HasColumnName("react_value");
            });

            modelBuilder.Entity<ReactValue>(entity =>
            {
                entity.ToTable("REACT_VALUE");

                entity.Property(e => e.ReactValueId)
                    .HasColumnName("react_value_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ReactDescription)
                    .HasMaxLength(64)
                    .HasColumnName("react_description");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("TOPICS");

                entity.HasIndex(e => e.TopicName, "UQ__TOPICS__54BAE5EC8EC4A43C")
                    .IsUnique();

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TopicDescription)
                    .HasColumnType("text")
                    .HasColumnName("topic_description");

                entity.Property(e => e.TopicName)
                    .HasMaxLength(255)
                    .HasColumnName("topic_name");

                entity.Property(e => e.TopicOwner).HasColumnName("topic_owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
