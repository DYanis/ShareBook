using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareBook.Models;
using ShareBook.Data.DbModels;

namespace ShareBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<UsersBook> UsersBook { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderStates> OrderStates { get; set; }

        public DbSet<ReportForOrder> ReportForOrder { get; set; }

        public DbSet<ReportForUser> ReportForUser { get; set; }
        
        public DbSet<Gender> Genders { get; set; }

        public DbSet<UserStatus> UserStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
