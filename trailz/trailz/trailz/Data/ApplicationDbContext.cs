using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using trailz.Areas.Identity.Data;
using trailz.Models;

namespace trailz.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoggedInUser> LoggedInUsers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RouteAttribute> RouteAttributes { get; set; }
        public DbSet<LoggedInUserRequest> LoggedInUserRequests { get; set; }
        public DbSet<AttributeType> AttributeTypes{ get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Trailz");
            base.OnModelCreating(modelBuilder);

            #region LoggedInUser
            modelBuilder.Entity<LoggedInUser>().ToTable("LoggedInUser");
            modelBuilder.Entity<LoggedInUser>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<LoggedInUser>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<LoggedInUser>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<LoggedInUser>().HasIndex(p => p.Email).IsUnique();
           
            #endregion

            #region CustomUser
            modelBuilder.Entity<CustomUser>()
                .HasOne(k => k.LoggedInUser)
                .WithOne(c => c.CustomUser)
                .HasForeignKey<LoggedInUser>(K => K.UserID);
            #endregion

            #region Route
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Route>().Property(p => p.RouteDate).IsRequired();
            modelBuilder.Entity<Route>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Route>().Property(p => p.RouteName).IsRequired();
            modelBuilder.Entity<Route>().Property(p => p.Distance).IsRequired();
            modelBuilder.Entity<Route>().Property(p => p.Departure).IsRequired();
            modelBuilder.Entity<Route>().Property(p => p.Arrival).IsRequired();
            #endregion
            #region Review
            modelBuilder.Entity<Review>().ToTable("Review");
            #endregion
            #region UserRequest
            modelBuilder.Entity<LoggedInUserRequest>().ToTable("UserRequest");
            modelBuilder.Entity<LoggedInUserRequest>().Property(p => p.RequestDate).IsRequired();
            modelBuilder.Entity<LoggedInUserRequest>().HasOne(p => p.Route).WithMany(p => p.LoggedInUserRequests).OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region RouteAttribute
            modelBuilder.Entity<RouteAttribute>().ToTable("RouteAttribute");
            #endregion
            #region Attribute
            modelBuilder.Entity<AttributeType>().ToTable("Attribute");
            modelBuilder.Entity<AttributeType>().Property(p => p.Name).IsRequired();
            #endregion
            #region Type
            modelBuilder.Entity<RouteType>().ToTable("Type");
            modelBuilder.Entity<Level>().Property(p => p.Name).IsRequired();
            #endregion
            #region Level
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<Level>().Property(p => p.Name).IsRequired();
            #endregion
        }

    }
}
