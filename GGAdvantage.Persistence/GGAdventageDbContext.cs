using GGAdvantage.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Persistence
{
    public class GGAdventageDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public GGAdventageDbContext(DbContextOptions<GGAdventageDbContext> options) 
            : base(options){ }

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemSubclass> ItemSubclass { get; set; }

        public DbSet<ItemClass> ItemClass { get; set; }

        public DbSet<Realm> Realm { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<AuctionCurrent> AuctionCurrent { get; set; }

        public DbSet<AuctionCurrentRealmAssoc> AuctionCurrentRealmAssoc { get; set; }
         
        public DbSet<AuctionDailyStatistic> AuctionDailyStatistic { get; set; }

        public DbSet<AuctionDailyStatisticRealmAssoc> AuctionDailyStatisticRealmAssoc { get; set; }

        public DbSet<AuctionTimeLeftLU> AuctionTimeLeftLU { get; set; }

        public DbSet<MarketNotification> MarketNotification { get; set; }

        public DbSet<MarketNotificationTypeLU> MarketNotificationTypeLU { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(b =>
            {
                b.ToTable("User");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("UserClaim");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.ToTable("UserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("UserToken");
            });

            modelBuilder.Entity<IdentityRole<int>>(b =>
            {
                b.ToTable("Role");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.ToTable("RoleClaim");
            });

            modelBuilder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("UserRole");
            });
        }
    }
}
