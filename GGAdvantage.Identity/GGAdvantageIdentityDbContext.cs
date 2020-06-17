using GGAdvantage.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Persistence
{
    public class GGAdvantageIdentityDbContext : IdentityDbContext<AppUser>
    {
        public GGAdvantageIdentityDbContext(DbContextOptions<GGAdvantageIdentityDbContext> options) 
            : base(options){ }

        //public DbSet<Item> Item { get; set; }

        public DbSet<AppUser> ItemSubclass { get; set; }
    }
}
