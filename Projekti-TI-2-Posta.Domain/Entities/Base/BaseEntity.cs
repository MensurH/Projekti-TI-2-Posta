using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime InsertData { get; set; }
        public string InsertBy { get; set; }
        public string LUB { get; set; }
        public DateTime LUD { get; set; }
        public int LUN { get; set; }
    }
}
