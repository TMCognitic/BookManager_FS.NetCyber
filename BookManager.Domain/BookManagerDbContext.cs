using BookManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Domain
{
    public class BookManagerDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get { return Set<Utilisateur>(); } }
        public DbSet<Livre> Livres { get { return Set<Livre>(); } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookManager;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
