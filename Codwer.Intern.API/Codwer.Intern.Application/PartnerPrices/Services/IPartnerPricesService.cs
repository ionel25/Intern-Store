using Codwer.Intern.DataTransferObjects.PartnerPrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.PartnerPrices.Services
{
    public interface IPartnerPricesService
    {
        Task<List<string>> GetPartnerPrices();
        Task<int> AddPartnerPrices(PartnerPriceDTO obj);
        Task<PartnerPriceDTO> UpdatePartnerPrices(PartnerPriceDTO obj);
        Task<PartnerPriceDTO> DeletePartnerPrices(PartnerPriceDTO obj);
    }
}