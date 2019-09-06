using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMerchTracker.Models;

namespace MyMerchTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<ApplicationUser>  ApplicationUsers { get; set; }

        public DbSet<Merch> Merch { get; set; }

        public DbSet<MerchType> MerchType { get; set; }



    }
}

