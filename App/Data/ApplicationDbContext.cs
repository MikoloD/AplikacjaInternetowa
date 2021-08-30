using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Multimedium> Multimedia { get; set; }
        public DbSet<IssueModel> Issues { get; set; }
        public DbSet<MalfunctionModel> Malfunctions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IssueModel>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Issue)
                .HasForeignKey(x => x.IssueId);
            builder.Entity<MalfunctionModel>()
                .HasMany(x => x.Issues)
                .WithOne(x => x.Malfunction)
                .HasForeignKey(x => x.MalfunctionId);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        }
    }
}
