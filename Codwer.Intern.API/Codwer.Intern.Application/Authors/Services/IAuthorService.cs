using Codwer.Intern.DataTransferObjects.Authors;
using Codwer.Intern.DataTransferObjects.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Authors.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAuth();
        Task<int> SetAuth(AuthorDTO obj);
        Task<AuthorDTO> UpdateAuth(AuthorDTO obj);
        Task<AuthorDTO> DeleteAuth(AuthorDTO obj);
    }
}
