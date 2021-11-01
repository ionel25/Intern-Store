using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codwer.Intern.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LHM98B2\MSSQLSERVER01;Database=test;Trusted_Connection = True;");
        }

        public AppDbContext()
        {
        }
        public virtual DbSet<Book> Books { get; set; }
    }
}
