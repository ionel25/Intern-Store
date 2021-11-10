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
        private readonly AppDbContext _appDbContext1;
        
      

        public BookService(AppDbContext appDbContext, AppDbContext appDbContext1)
        {
            _appDbContext = appDbContext;
            _appDbContext1 = appDbContext1;
        }

        public async Task<List<string>> GetBooksName()
        {
            return await _appDbContext.Books.Select(s => s.Name).ToListAsync();

        }



        public async Task<List<System.DateTime>> GetBooksYear()
        {
            return await _appDbContext.Books.Select(s => s.Year).Take(3).ToListAsync();
        }
         


        public async Task<List<BookInformation>> GetAllInformation()
        {
            return await _appDbContext.Books
                .Where(s => s.Id > 1)
                .Select(s => new BookInformation
                {
                    Id=s.Id,
                    Name = s.Name,
                    AuthorId = s.AuthorId,
                    Year = s.Year
                }) 
                .ToListAsync();
        }

        public async Task<List<BookInformation>> GetAllInformationEdit(int id)
        {
            return await _appDbContext.Books.
                Where(s => s.EditionId == id).
                Select(s => new BookInformation
                {
                    Id = s.Id,
                    Name = s.Name,
                    Year = s.Year,
                    AuthorId = s.AuthorId,
                    EditionId = s.EditionId,
                    CoverID = s.CoverID,
                    PartnerPriceID = s.PartnerPriceID,
                    LanguageID = s.LanguageID

                }).ToListAsync();
        }


        public async Task<AuthorObj> SetAuthor(AuthorObj obj)
        {

            var test = new Author
            {
                FirstName = obj.Name,
                Surname = obj.SurName
            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();

            return await _appDbContext1.Author.Where(s=>s.Id==test.Id).Select(s => new AuthorObj
            {
                Name = s.Surname,
               SurName = s.FirstName

            }).FirstOrDefaultAsync();
        }

        public async Task<CoverDto> SetCover(CoverDto obj)
        {
            var test = new Cover
            {
                Coveer = obj.Coveer
            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();
            return await _appDbContext.Covers.Where(s => s.ID == test.ID).Select(s => new CoverDto
            {
                Coveer = s.Coveer

            }).FirstOrDefaultAsync();

        }

        public async Task<EditionDbo> SetEdition(EditionDbo obj)
        {
            var test = new Edition
            {
                Name = obj.Name
            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();
            return await _appDbContext.Edition.
                Where(s => s.Id == test.Id).
                Select(s => new EditionDbo
                {
                    Name = s.Name

                }).FirstOrDefaultAsync();

        }

        public async Task<LanguageDbo> SetLanguage(LanguageDbo obj)
        {
            var test = new Language
            {
                Name = obj.Name 


            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();

            return await _appDbContext.Languages
                .Where(s => s.ID == test.ID)
                .Select(s => new LanguageDbo
                {
                    Name = s.Name

                }).FirstOrDefaultAsync();

        }

        public async Task<PartnerDbo> SetPartner(PartnerDbo obj)
        {
            var test = new PartnerPrice
            {
                Partner = obj.Name,
                Price = obj.Price
            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();

            return await _appDbContext.PartnerPrices
                .Where(s => s.ID == test.ID).Select(s => new PartnerDbo
                {
                    Name = s.Partner,
                    Price = s.Price


                }).FirstOrDefaultAsync();
        }

        public async Task<TypeDbo> SetType(TypeDbo obj)
        {
            var test = new Type
            {
                Name = obj.Name
            };

            await _appDbContext.AddAsync(test);
            _appDbContext.SaveChanges();

            return await _appDbContext.Type
                .Where(s => s.Id == test.Id)
                .Select(s => new TypeDbo
                {
                    Name = s.Name

                }).FirstOrDefaultAsync();

        }

        public async Task<BookInformation> SetBookInfo(BookInformationWithoutID book)
        {
            var line = new Book
            {
                Name = book.Name,
                Year = book.Year,
                AuthorId = book.AuthorId,
                EditionId = book.EditionId,
                CoverID = book.CoverID,
                PartnerPriceID = book.PartnerPriceID,
                LanguageID = book.LanguageID


            };
            await _appDbContext.AddAsync(line);
            _appDbContext.SaveChanges();
            return await _appDbContext.Books.Select(s => new BookInformation
            {
                Name = s.Name,
                Year = s.Year,
                AuthorId = s.AuthorId,
                EditionId = s.EditionId,
                CoverID = s.CoverID,
                PartnerPriceID = s.PartnerPriceID,
                LanguageID = s.LanguageID
            }).FirstOrDefaultAsync();
        }



        public async Task<List<BookInformation>> DeleteBook (int bookid)
        {
                       
            var test = _appDbContext.Books.Where(s => s.Id == bookid).FirstOrDefault();
            if(test != null)
            {
                _appDbContext.Books.Remove(test);
                _appDbContext.SaveChanges();
                 
            }

            //return await _appDbContext.Books
            //        .Select(s => new BookInformation 
            //        { 
            //            Id = s.Id,
            //            Name = s.Name,
            //            AuthorId = s.AuthorId,
            //            IDLanguage = s.IDLanguage 
            //        }).ToListAsync();
            return await GetAllInformation();
                                
       }

      public async  Task<bool> UpDateAuthor(int authorId, AuthorObj obj)
        {
            var test = _appDbContext.Author.Where(s => s.Id == authorId).FirstOrDefault();
            if(test != null)
            {
                test.FirstName = obj.Name;
                test.Surname = obj.SurName;

                _appDbContext.Author.Update(test);
                _appDbContext.SaveChanges();
                return  true;
            }
            else
            {
                return  false;
            }
        }
      


    }
}
