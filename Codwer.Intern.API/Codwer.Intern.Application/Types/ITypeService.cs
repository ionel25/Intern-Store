using Codwer.Intern.DataTransferObjects.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.Application.Types.Services
{
    public interface ITypeService
    {
        Task<List<string>> GetTypes();
        Task<int> AddTypes(TypeDTO obj);
        Task<TypeDTO> UpdateTypes(TypeDTO obj);
        Task<TypeDTO> DeleteTypes(TypeDTO obj);
    }
}
