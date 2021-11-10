using Codwer.Intern.DataTransferObjects.Books;
using Codwer.Intern.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Books.Services
{
    public interface IBookService
    {
        Task<List<string>> GetBooksName();
        Task<List<DateTime>> GetBooksYear(int page,int produ);
        Task<List<BookInformation>> GetAllInformation();
        Task<AuthorObj> SetAuthor(AuthorObj obj);
        Task<List<BookInformation>> DeleteBook(int bookid);
        Task<CoverDto> SetCover(CoverDto obj);
        Task<EditionDbo> SetEdition(EditionDbo obj);
        Task<PartnerDbo> SetPartner(PartnerDbo obj);
        Task<LanguageDbo> SetLanguage(LanguageDbo obj);
        Task<TypeDbo> SetType(TypeDbo obj);
        Task<bool> UpDateAuthor(int authorId, AuthorObj obj);
        Task<BookInformation> SetBookInfo(BookInformationWithoutID obj);
        Task<List<BookInformation> >GetAllInformationEdit(int id);
    }
}
