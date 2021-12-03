using Codwer.Intern.Application.Types.Services;
using Codwer.Intern.DataTransferObjects.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet("get-type")]
        public async Task<List<string>> GetType()
        {
            return await _typeService.GetTypes();
        }

        [HttpPost("add-type")]
        public async Task<int> AddType([FromBody] TypeDTO obj)
        {
            return await _typeService.AddTypes(obj);
        }

        [HttpPut("update-type")]
        public async Task<TypeDTO> UpdateType(TypeDTO obj)
        {
            return await _typeService.UpdateTypes(obj);
        }

        [HttpDelete("delete-type")]
        public async Task<TypeDTO> DeleteType(TypeDTO obj)
        {
            return await _typeService.DeleteTypes(obj);
        }
    }
}