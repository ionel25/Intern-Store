using Codwer.Intern.DataTransferObjects.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Languages.Services
{
    public interface ILanguageService
    {
        Task<List<string>> GetLanguages();
        Task<int> AddLanguages(LanguageDTO obj);
        Task<LanguageDTO> UpdateLanguages(LanguageDTO obj);
        Task<LanguageDTO> DeleteLanguages(LanguageDTO obj);
    }
}