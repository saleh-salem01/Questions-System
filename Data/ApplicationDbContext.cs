using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jocksWebApp.Models;

namespace jocksWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<jocksWebApp.Models.joke> joke { get; set; } = default!;
        public DbSet<jocksWebApp.Models.QAnswer> QAnswer { get; set; } = default!;
    }
}
