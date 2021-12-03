using Codwer.Intern.Application.Types.Services;
using Codwer.Intern.DataTransferObjects.Types;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Types.Services.Implementations
{
    public class TypeService : ITypeService
    {
        private readonly AppDbContext _appDbContext;

        public TypeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetTypes()
        {
            return await _appDbContext.Type.Select(s => s.Name).ToListAsync();
        }

        public async Task<int> AddTypes(TypeDTO obj)
        {
            var type = new Type
            {
                Name = obj.Name
            };

            await _appDbContext.AddAsync(type);
            await _appDbContext.SaveChangesAsync();

            return type.Id;
        }

        public async Task<TypeDTO> UpdateTypes(TypeDTO obj)
        {
            var type = _appDbContext.Type
                .Where(a => a.Id == obj.Id)
                .FirstOrDefault();

            type.Name = obj.Name;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<TypeDTO> DeleteTypes(TypeDTO obj)
        {
            var type = await _appDbContext.Type
                .Where(a => a.Id == obj.Id)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(type);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
