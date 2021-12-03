using System.Collections.Generic;
using System.Threading.Tasks;
using Codwer.Intern.Application.Books.Services;
using Microsoft.AspNetCore.Mvc;
using Codwer.Intern.DataTransferObjects.Books;


namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-books")]
        public async Task<List<string>> GetBook()
        {
            return await _bookService.GetBooks();
        }

        [HttpPost("add-book")]
        public async Task<int> AddBook([FromBody]BookDTO obj)
        {
            return await _bookService.AddBooks(obj);
        }

        [HttpPut("update-book")]
        public async Task<BookDTO> UpdateBook(BookDTO obj)
        {
            return await _bookService.UpdateBooks(obj);
        }

        [HttpDelete("delete-book")]
        public async Task<BookDTO> DeleteBook(BookDTO obj)
        {
            return await _bookService.DeleteBooks(obj);
        }
    }
}

