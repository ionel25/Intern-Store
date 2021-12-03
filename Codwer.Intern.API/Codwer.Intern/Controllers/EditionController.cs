using Codwer.Intern.Application.Editions.Services;
using Codwer.Intern.DataTransferObjects.Editions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class EditionController : Controller
    {
        private readonly IEditionService _editionService;

        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet("get-edition")]
        public async Task<List<string>> GetEdition()
        {
            return await _editionService.GetEditions();
        }

        [HttpPost("add-edition")]
        public async Task<int> AddEdition([FromBody] EditionDTO obj)
        {
            return await _editionService.AddEditions(obj);
        }

        [HttpPut("update-edition")]
        public async Task<EditionDTO> UpdateEdition(EditionDTO obj)
        {
            return await _editionService.UpdateEditions(obj);
        }

        [HttpDelete("delete-edition")]
        public async Task<EditionDTO> DeleteEdition(EditionDTO obj)
        {
            return await _editionService.DeleteEditions(obj);
        }
    }
}
