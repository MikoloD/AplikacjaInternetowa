using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApp.Models
{
    public class Context : DbContext
    {
        public DbSet<Issue> Zgloszenia { get; set; }
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }
    }
}
