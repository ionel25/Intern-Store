using Codwer.Intern.Application.Covers.Services;
using Codwer.Intern.DataTransferObjects.Covers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class CoverController : Controller
    {
        private readonly ICoverService _coverService;

        public CoverController(ICoverService coverService)
        {
            _coverService = coverService;
        }

        [HttpGet("get-cover")]
        public async Task<List<string>> GetCover()
        {
            return await _coverService.GetCovers();
        }

        [HttpPost("add-cover")]
        public async Task<int> AddCover([FromBody] CoverDTO obj)
        {
            return await _coverService.AddCovers(obj);
        }

        [HttpPut("update-cover")]
        public async Task<CoverDTO> UpdateCover(CoverDTO obj)
        {
            return await _coverService.UpdateCovers(obj);
        }

        [HttpDelete("delete-cover")]
        public async Task<CoverDTO> DeleteCover(CoverDTO obj)
        {
            return await _coverService.DeleteCovers(obj);
        }
    }
}
