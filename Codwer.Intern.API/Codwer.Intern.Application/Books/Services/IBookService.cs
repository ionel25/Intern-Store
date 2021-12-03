using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codwer.Intern.DataTransferObjects.Books;

namespace Codwer.Intern.Application.Books.Services
{
    public interface IBookService
    {
        Task<List<string>> GetBooks();
        Task<int> AddBooks(BookDTO obj);
        Task<BookDTO> UpdateBooks(BookDTO obj);
        Task<BookDTO> DeleteBooks(BookDTO obj);
    }
}
