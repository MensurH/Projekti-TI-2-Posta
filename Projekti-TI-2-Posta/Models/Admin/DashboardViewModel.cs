using Projekti_TI_2_Posta.Infrastructure.Identity;
using Projekti_TI_2_Posta.Models.Porosia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Models.Admin
{
    public class DashboardViewModel
    {
        public IEnumerable<GetPorosiaModel> Porosiat { get; set; }

        public IEnumerable<GetPorosiaModel> PorosiatByUser { get; set; }
        public IEnumerable<GetPorosiaModel> PorosiatByPostier { get; set; }
    }
}
