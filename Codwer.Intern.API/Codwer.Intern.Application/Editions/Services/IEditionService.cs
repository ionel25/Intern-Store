using Codwer.Intern.DataTransferObjects.Editions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Editions.Services
{
    public interface IEditionService
    {
        Task<List<string>> GetEditions();
        Task<int> AddEditions(EditionDTO obj);
        Task<EditionDTO> UpdateEditions(EditionDTO obj);
        Task<EditionDTO> DeleteEditions(EditionDTO obj);
    }
}
