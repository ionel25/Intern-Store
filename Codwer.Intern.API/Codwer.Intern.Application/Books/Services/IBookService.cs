using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Books.Services
{
    public interface IBookService
    {
        Task<List<string>> GetBooksName();
        Task<List<string>> GetBooksAuthor();
    }
}
