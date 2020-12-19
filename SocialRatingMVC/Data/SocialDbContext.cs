using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialRatingMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialRatingMVC.Data
{
    public class SocialDbContext : IdentityDbContext<User>
    {
        public SocialDbContext(DbContextOptions<SocialDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<FriendshipStatus> FriendshipStatuses { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserFriend>()
                .HasKey(uf => new { uf.UserId, uf.FriendId });
            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.User)
                .WithMany(user => user.Friends)
                .HasForeignKey(user => user.UserId);
            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.User)
                .WithMany(user => user.Friends)
                .HasForeignKey(user => user.FriendId);

            modelBuilder.Entity<UserFriend>().ToTable("UserFriend");
            modelBuilder.Entity<FriendshipStatus>().ToTable("FriendshipStatus");
            modelBuilder.Entity<Reaction>().ToTable("Reaction");



        }
    }
}
