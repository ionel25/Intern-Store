using Codwer.Intern.DataTransferObjects.Covers;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Covers.Services.Implementations
{
    public class CoverService : ICoverService
    {
        private readonly AppDbContext _appDbContext;

        public CoverService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetCovers()
        {
            return await _appDbContext.Covers.Select(s => s.Coveer).ToListAsync();
        }

        public async Task<int> AddCovers(CoverDTO obj)
        {
            var cover = new Cover
            {    
                Coveer=obj.Cover
            };

            await _appDbContext.AddAsync(cover);
            await _appDbContext.SaveChangesAsync();

            return cover.ID;
        }

        public async Task<CoverDTO> UpdateCovers(CoverDTO obj)
        {
            var cover = _appDbContext.Covers
                .Where(a => a.ID == obj.Id)
                .FirstOrDefault();

            cover.Coveer = obj.Cover;
            
            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<CoverDTO> DeleteCovers(CoverDTO obj)
        {
            var cover = await _appDbContext.Covers
                .Where(a => a.ID == obj.Id)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(cover);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
