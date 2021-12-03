using Codwer.Intern.DataTransferObjects.Languages;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Languages.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly AppDbContext _appDbContext;

        public LanguageService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetLanguages()
        {
            return await _appDbContext.Languages.Select(s => s.Name).ToListAsync();
        }

        public async Task<int> AddLanguages(LanguageDTO obj)
        {
            var language = new Language
            {
                Name = obj.Name
            };

            await _appDbContext.AddAsync(language);
            await _appDbContext.SaveChangesAsync();

            return language.ID;
        }

        public async Task<LanguageDTO> UpdateLanguages(LanguageDTO obj)
        {
            var language = _appDbContext.Languages
                .Where(a => a.ID == obj.Id)
                .FirstOrDefault();

            language.Name = obj.Name;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<LanguageDTO> DeleteLanguages(LanguageDTO obj)
        {
            var language = await _appDbContext.Languages
                .Where(a => a.ID == obj.Id)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(language);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}