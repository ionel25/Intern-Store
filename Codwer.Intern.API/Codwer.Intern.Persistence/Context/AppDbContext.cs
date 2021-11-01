using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codwer.Intern.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=localDatabase;Trusted_Connection = True;");
=======
            optionsBuilder.UseSqlServer(@"Server=localhost ;Database=localDatabase;Trusted_Connection = True;");
>>>>>>> 657f03c61e2ea4dbdda2e9f7500da989e0947487
        }

        public AppDbContext()
        {
        }
        public virtual DbSet<Book> Books { get; set; }
<<<<<<< HEAD
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Edition> Edition { get; set; }
        public virtual DbSet<Type> Type { get; set; }

=======
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<PartnerPrice> PartnerPrices  { get; set; }
>>>>>>> 657f03c61e2ea4dbdda2e9f7500da989e0947487
    }

}
