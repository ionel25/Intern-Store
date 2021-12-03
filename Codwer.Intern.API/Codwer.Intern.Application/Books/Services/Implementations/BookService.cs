using Codwer.Intern.DataTransferObjects.Books;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Books.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _appDbContext;

        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetBooks()
        {
            return await _appDbContext.Books.Select(s => s.Name).ToListAsync();
        }

        public async Task<int> AddBooks(BookDTO obj)
        {
            var book = new Book
            {
                Name = obj.Name,
                Year = obj.Year,
                AuthorId = obj.AuthorId,
                EditionId = obj.EditionId,
                CoverID = obj.CoverID,
                PartnerPriceID = obj.PartnerPriceID,
                LanguageID = obj.LanguageID

            };

            await _appDbContext.AddAsync(book);
            await _appDbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<BookDTO> UpdateBooks(BookDTO obj)
        {
            var book = _appDbContext.Books
                .Where(a => a.Id == obj.Id)
                .FirstOrDefault();

            book.Id = obj.Id;
            book.Name = obj.Name;
            book.Year = obj.Year;
            book.AuthorId = obj.AuthorId;
            book.EditionId = obj.EditionId;
            book.CoverID = obj.CoverID;
            book.PartnerPriceID = obj.PartnerPriceID;
            book.LanguageID = obj.LanguageID;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<BookDTO> DeleteBooks(BookDTO obj)
        {
            var auth = await _appDbContext.Books
                .Where(a => a.Id == obj.Id)
                .Where(a => a.Name == obj.Name)
                .Where(a => a.AuthorId == obj.AuthorId)
                .Where(a => a.EditionId == obj.EditionId)
                .Where(a => a.CoverID == obj.CoverID)
                .Where(a => a.PartnerPriceID == obj.PartnerPriceID)
                .Where(a => a.LanguageID == obj.LanguageID)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(auth);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
