using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoreAutomotive.Models
{
    public class AppDbContext : IdentityDbContext<UserData, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinia> Opinie { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }
}
