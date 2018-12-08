using Microsoft.EntityFrameworkCore;


namespace WebApplication2.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions builder) : base(builder) { }
        public DbSet<AccountType> accountTypes { get; set; }
        public DbSet<Etablishment> etablishments { get; set; }
        public DbSet<UserEtablishment> userEtablishment { get; set; }
        public DbSet<User> user { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<UserEtablishment>().HasKey(f => new {f.etablishmentID, f.userID });
            model.Entity<User>().HasOne<AccountType>(s => s.AccountType);
            model.Entity<Rating>().HasKey(f => new { f.etablishmentID, f.userID });
        }
    }
    
}
