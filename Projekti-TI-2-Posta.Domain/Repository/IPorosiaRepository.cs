using Projekti_TI_2_Posta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Domain.Repository
{
   public interface IPorosiaRepository
    {
        Task<IEnumerable<Porosia>> GetAllPorosi(string userid, string postierid,string search);
        Task<Porosia> GetPorosiaById(int id);
        void CreatePorosi(Porosia porosia);
        void UpdatePorosi(Porosia porosi);
        void DeletePorosi(int id);


    }
}
