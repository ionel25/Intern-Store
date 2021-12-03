using Codwer.Intern.Application.PartnerPrices.Services;
using Codwer.Intern.DataTransferObjects.PartnerPrices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class PartnerPriceController : Controller
    {
        private readonly IPartnerPricesService _partnerPricesService;

        public PartnerPriceController(IPartnerPricesService partnerPricesService)
        {
            _partnerPricesService = partnerPricesService;
        }

        [HttpGet("get-partner-price")]
        public async Task<List<string>> GetPartnerPrice()
        {
            return await _partnerPricesService.GetPartnerPrices();
        }

        [HttpPost("add-partner-price")]
        public async Task<int> AddPartnerPrice([FromBody] PartnerPriceDTO obj)
        {
            return await _partnerPricesService.AddPartnerPrices(obj);
        }

        [HttpPut("update-partner-price")]
        public async Task<PartnerPriceDTO> UpdatePartnerPrice(PartnerPriceDTO obj)
        {
            return await _partnerPricesService.UpdatePartnerPrices(obj);
        }

        [HttpDelete("delete-partner-price")]
        public async Task<PartnerPriceDTO> DeletePartnerPrices(PartnerPriceDTO obj)
        {
            return await _partnerPricesService.DeletePartnerPrices(obj);
        }
    }
}