﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlijterijSjonnieLoper.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlijterijSjonnieLoper.Data
{
    public class SjonnieLoperDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Whiskey> Whiskeys { get; set; }
        //public DbSet<ApplicationUser> applicationUsers { get; set; }

        public SjonnieLoperDbContext(DbContextOptions<SjonnieLoperDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
