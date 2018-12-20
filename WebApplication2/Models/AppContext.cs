using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;


namespace WebApplication2.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions builder) : base(builder) { }
        public DbSet<AccountType> accountTypes { get; set; }
        public DbSet<Etablishment> etablishment { get; set; }
        public DbSet<UserEtablishment> userEtablishment { get; set; }
        public DbSet<Chamber> chamber { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<EtablishmentType> etablishmentType { get; set; }
        

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<UserEtablishment>().HasKey(f => new {f.etablishmentID, f.userID });
            model.Entity<User>().HasOne<AccountType>(s => s.AccountType);
            model.Entity<Comment>().HasKey(f => new { f.etablishmentID, f.userID });
            
        }
        

        public DbSet<WebApplication2.Models.Reservation> Reservation { get; set; }
    }
    
}
