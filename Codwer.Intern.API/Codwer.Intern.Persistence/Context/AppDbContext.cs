using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codwer.Intern.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {  
        }

        public DbSet<Book> Books { get; set; }
    }
}
