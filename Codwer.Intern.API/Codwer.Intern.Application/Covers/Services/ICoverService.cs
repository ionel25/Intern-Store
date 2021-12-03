using Codwer.Intern.DataTransferObjects.Covers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Covers.Services
{
    public interface ICoverService
    {
        Task<List<string>> GetCovers();
        Task<int> AddCovers(CoverDTO obj);
        Task<CoverDTO> UpdateCovers(CoverDTO obj);
        Task<CoverDTO> DeleteCovers(CoverDTO obj);
    }
}
