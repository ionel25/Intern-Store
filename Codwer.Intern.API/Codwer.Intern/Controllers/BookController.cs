using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Codwer.Intern.Application.Books.Services;
using Codwer.Intern.DataTransferObjects.Books;
using Codwer.Intern.Persistence.Entities;
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
        //Extrage informatia din baza de date
        [HttpGet("year")]
        public async Task<List<DateTime>> GetYear(int page,int produs)
        {
            return await _bookService.GetBooksYear(page,produs);
        }

        [HttpGet("all-information")]
        public async Task<List<BookInformation>> GetAllInformation()
        {
            return await _bookService.GetAllInformation();
        }
        [HttpGet("GetEditionID")]
        public async Task<List<BookInformation>> GetAllBooksEditID(int id)
        {
            return await _bookService.GetAllInformationEdit(id);
        }

        
        
        
        
        
        
        //Adauga date in baza de daste si anume intr-un anumit tabel
        [HttpPost("introduction-info-Author")]
        public async Task<AuthorObj> SetAuthor( AuthorObj obj)
        {
            return await _bookService.SetAuthor(obj);
        }
       
        [HttpPost("Introduction-info-Cover")]
        public async Task<CoverDto> SetCover( CoverDto obj)
        {
            return await _bookService.SetCover(obj);

        }
        
        [HttpPost("edition")]
        public async Task<EditionDbo> SetEdition(EditionDbo obj)
        {
            return await _bookService.SetEdition(obj);

        }
        [HttpPost("partner")]
        public async Task<PartnerDbo> SetPartner(PartnerDbo obj)
        {
            return await _bookService.SetPartner(obj);

        }
        [HttpPost("Language")]
        public async Task<LanguageDbo> SetLanguage(LanguageDbo obj)
        {
            return await _bookService.SetLanguage(obj);

        }
        [HttpPost("Type")]
        public async Task<TypeDbo> SetType(TypeDbo obj)
        {
            return await _bookService.SetType(obj);

        }

        [HttpPost("allbooksIdinfor")]
        public async Task<BookInformation> SetBookInfo(BookInformationWithoutID obj)
        {
            return await _bookService.SetBookInfo(obj);
        }



        //Sterge date din baza de date 

        [HttpDelete("delete-Information")]
        public async Task<List<BookInformation>> DeleteBooks(int bookid)
        {
            return await _bookService.DeleteBook(bookid);
        }
            
    
        //HttpPut -Face update in baza de date
        [HttpPut("modify-author")]
        public async Task<bool> UpDateAuthor(int authorId, AuthorObj obj)
        {
            return await _bookService.UpDateAuthor(authorId, obj);
                
        }

        
    
    
    
    
    
    }
}
