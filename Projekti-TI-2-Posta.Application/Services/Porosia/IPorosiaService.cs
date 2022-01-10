using Projekti_TI_2_Posta.Application.Dtos.Porosia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Application.Services.Porosia
{
    public interface IPorosiaService
    {
        Task<IEnumerable<GetPorosiaDto>> GetAllPorosi(string userid,string postierid,string search);
        Task<GetPorosiaDto> GetPorosiById(int id);
        void CreatePorosi(CreatePorosiaDto porosiaDto);
        void UpdatePorosi(UpdatePorosiaDto updatePorosia);
        void DeletePorosi(int id);


    }
}
