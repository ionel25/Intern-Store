using Codwer.Intern.Application.Authors.Services;
using Codwer.Intern.DataTransferObjects.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController: Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("get-authors")]
        public async Task<List<AuthorDTO>> GetAuthor()
        {
            return await _authorService.GetAuth();
        }

        [HttpPost("add-author")]
        public async Task<int> SetAuthor([FromBody]AuthorDTO obj)
        {
            return await _authorService.SetAuth(obj);
        }

        [HttpPut("update-author")]
        public async Task<AuthorDTO> UpdateAuthor( AuthorDTO obj)
        {
            return await _authorService.UpdateAuth(obj);
        }

        [HttpDelete("delete-author")]
        public async Task<AuthorDTO> DeleteAuthor(AuthorDTO obj)
        {
            return await _authorService.DeleteAuth(obj);
        }
    }
}
