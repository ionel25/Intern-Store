using Codwer.Intern.DataTransferObjects.Authors;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Authors.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _appDbContext;

        public AuthorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<AuthorDTO>> GetAuth()
        {
            return await _appDbContext.Author
                .Select(a => new AuthorDTO
                {
                    Id=a.Id,
                    Name = a.FirstName,
                    SurName = a.Surname
                }).ToListAsync();
        }

        public async Task<int> SetAuth(AuthorDTO obj)
        {
            var auth = new Author
            {
                
                FirstName = obj.Name,
                Surname = obj.SurName
            };

            await _appDbContext.AddAsync(auth);
            await _appDbContext.SaveChangesAsync();

            return auth.Id;
        }

        public async Task<AuthorDTO> UpdateAuth(AuthorDTO obj)
        {
            var dbAuthor = _appDbContext.Author
                .Where(a => a.Id == obj.Id)
                .FirstOrDefault();

            dbAuthor.Surname = obj.SurName;
            dbAuthor.FirstName = obj.Name;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<AuthorDTO> DeleteAuth(AuthorDTO obj)
        {
            var auth = await _appDbContext.Author
                .Where(a => a.Id == obj.Id)
                .Where(a => a.FirstName == obj.Name)
                .Where(a => a.Surname == obj.SurName)
                .FirstOrDefaultAsync();


               _appDbContext.Remove(auth);
               _appDbContext.SaveChanges();

            return obj;
        }
    }
}
