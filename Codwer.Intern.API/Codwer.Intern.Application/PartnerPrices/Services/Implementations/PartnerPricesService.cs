using Codwer.Intern.Application.PartnerPrices.Services;
using Codwer.Intern.DataTransferObjects.PartnerPrices;
using Codwer.Intern.Persistence.Context;
using Codwer.Intern.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.PartnerPrices.Services.Implementations
{
    public class PartnerPricesService : IPartnerPricesService
    {
        private readonly AppDbContext _appDbContext;

        public PartnerPricesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> GetPartnerPrices()
        {
            return await _appDbContext.PartnerPrices.Select(s => s.Partner).ToListAsync();
        }

        public async Task<int> AddPartnerPrices(PartnerPriceDTO obj)
        {
            var partnerPrice = new PartnerPrice
            {
                Partner = obj.Name,
                Price=obj.Price
            };

            await _appDbContext.AddAsync(partnerPrice);
            await _appDbContext.SaveChangesAsync();

            return partnerPrice.ID;
        }

        public async Task<PartnerPriceDTO> UpdatePartnerPrices(PartnerPriceDTO obj)
        {
            var partnerPrice = _appDbContext.PartnerPrices
                .Where(a => a.ID == obj.Id)
                .FirstOrDefault();

            partnerPrice.Partner = obj.Name;
            partnerPrice.Price = obj.Price;

            await _appDbContext.SaveChangesAsync();

            return obj;
        }

        public async Task<PartnerPriceDTO> DeletePartnerPrices(PartnerPriceDTO obj)
        {
            var partnerPrice = await _appDbContext.PartnerPrices
                .Where(a => a.ID == obj.Id)
                .FirstOrDefaultAsync();

            _appDbContext.Remove(partnerPrice);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
