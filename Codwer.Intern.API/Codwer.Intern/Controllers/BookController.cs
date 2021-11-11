using System.Collections.Generic;
using System.Threading.Tasks;
using Codwer.Intern.Application.Books.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("names")]
        public async Task<List<string>> GetNames()
        {
            return await _bookService.GetBooksName();
        }

        [HttpGet("author")]
        public async Task<List<string>> GetAuthor()
        {
            return await _bookService.GetBooksAuthor();
        }
    }
}

