using Codwer.Intern.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Books.Services.Implementations
{
    public class BookService: IBookService
    {
        private readonly AppDbContext _appDbContext;
       
        public BookService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetBooksName()
        {
            return await _appDbContext.Books.Select(s => s.Name).ToListAsync();
        }
    }
}
