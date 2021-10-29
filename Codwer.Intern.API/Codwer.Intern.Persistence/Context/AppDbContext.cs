using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codwer.Intern.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localHost; user Id=local; password=root");
        }
        public AppDbContext()
        {
            
        }
        public virtual DbSet<Book> Books { get; set; }
    }
}
