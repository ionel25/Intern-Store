using Codwer.Intern.DataTransferObjects.Editions;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Editions.Services.Implementations
{
    public class EditionService : IEditionService
    {
        private readonly AppDbContext _appDbContext;

        public EditionService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetEditions()
        {
            return await _appDbContext.Edition.Select(s => s.Name).ToListAsync();
        }

        public async Task<int> AddEditions(EditionDTO obj)
        {
            var edition = new Edition
            {
                Name = obj.Name
            };

            await _appDbContext.AddAsync(edition);
            await _appDbContext.SaveChangesAsync();

            return edition.Id;
        }

        public async Task<EditionDTO> UpdateEditions(EditionDTO obj)
        {
            var edition = _appDbContext.Edition
                .Where(a => a.Id == obj.Id)
                .FirstOrDefault();

            edition.Name = obj.Name;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<EditionDTO> DeleteEditions(EditionDTO obj)
        {
            var edition = await _appDbContext.Edition
                .Where(a => a.Id == obj.Id)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(edition);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
