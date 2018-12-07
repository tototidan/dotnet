using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions builder) : base(builder) { }
        public DbSet<admins> Admins { get; set; }
    }
}
