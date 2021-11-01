using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Codwer.Intern.Persistence.Context;

namespace Codwer.Intern.Application.Books.Services.Implementations
{
    public class BookService : IBookService
    {

        private readonly AppDbContext appDbContext;
        public Task<List<string>> GetBooksName()
        {
            throw new NotImplementedException();
        }
    }
}
