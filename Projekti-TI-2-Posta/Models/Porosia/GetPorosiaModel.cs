using System;

namespace Projekti_TI_2_Posta.Models.Porosia
{
    public class GetPorosiaModel
    {
        public int ID { get; set; }

        public string UserID { get; set; }
        public string PostierID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Emertimi { get; set; }
        public int NrTelefonit { get; set; }
        public string Adresa { get; set; }
        public string Qyteti { get; set; }
        public string Shteti { get; set; }
        public bool ERegjistruar { get; set; }
        public bool EDerguar { get; set; }
        public int Pagesa { get; set; }

        public DateTime InsertData { get; set; }

    }
}
