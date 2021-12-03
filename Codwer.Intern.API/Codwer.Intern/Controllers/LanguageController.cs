using Codwer.Intern.Application.Languages.Services;
using Codwer.Intern.DataTransferObjects.Languages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codwer.Intern.Controllers
{
    [Route("api/[controller]")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("get-language")]
        public async Task<List<string>> GetLanguage()
        {
            return await _languageService.GetLanguages();
        }

        [HttpPost("add-language")]
        public async Task<int> AddLanguages([FromBody] LanguageDTO obj)
        {
            return await _languageService.AddLanguages(obj);
        }

        [HttpPut("update-language")]
        public async Task<LanguageDTO> UpdateLanguage(LanguageDTO obj)
        {
            return await _languageService.UpdateLanguages(obj);
        }

        [HttpDelete("delete-language")]
        public async Task<LanguageDTO> DeleteLanguage(LanguageDTO obj)
        {
            return await _languageService.DeleteLanguages(obj);
        }
    }
}

