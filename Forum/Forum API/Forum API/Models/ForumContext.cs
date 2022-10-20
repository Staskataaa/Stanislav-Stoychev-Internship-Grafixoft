using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum_API.Models
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
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<React> Reacts { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.HasIndex(e => e.Email, "UQ__ACCOUNT__AB6E6164B10C0B4C")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__ACCOUNT__F3DBC5724747B3A6")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountPassword)
                    .HasMaxLength(255)
                    .HasColumnName("account_password");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProfilePicPath)
                    .HasColumnType("text")
                    .HasColumnName("profile_pic_path");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.ReactId).HasColumnName("react_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_comment_post_id");

                entity.HasOne(d => d.React)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ReactId)
                    .HasConstraintName("fk_comment_react_id");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POST");

                entity.HasIndex(e => e.ReactId, "UQ__POST__1DEB4F6340565D31")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.ReactId).HasColumnName("react_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_post_account_id");

                entity.HasOne(d => d.React)
                    .WithOne(p => p.Post)
                    .HasForeignKey<Post>(d => d.ReactId)
                    .HasConstraintName("fk_post_react_id");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("fk_post_topic_id");
            });

            modelBuilder.Entity<React>(entity =>
            {
                entity.ToTable("REACT");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dislikes)
                    .HasColumnName("dislikes")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Likes)
                    .HasColumnName("likes")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("TOPIC");

                entity.HasIndex(e => e.TopicName, "UQ__TOPIC__54BAE5EC76E48F40")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TopicDescription)
                    .HasColumnType("text")
                    .HasColumnName("topic_description");

                entity.Property(e => e.TopicName)
                    .HasMaxLength(255)
                    .HasColumnName("topic_name");

                entity.Property(e => e.TopicOwner).HasColumnName("topic_owner");

                entity.HasOne(d => d.TopicOwnerNavigation)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.TopicOwner)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TOPIC__topic_own__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
