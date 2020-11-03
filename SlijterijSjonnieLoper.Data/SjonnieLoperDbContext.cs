using Microsoft.EntityFrameworkCore;
using SlijterijSjonnieLoper.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlijterijSjonnieLoper.Data
{
    public class SjonnieLoperDbContext : DbContext
    {
        public DbSet<Whiskey> Whiskeys { get; set; }
    }
}
