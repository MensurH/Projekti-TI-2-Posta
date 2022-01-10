using System;
using System.ComponentModel.DataAnnotations;

namespace Projekti_TI_2_Posta.Models.Porosia
{
    public class UpdatePorosiaModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string PostierID { get; set; }
        [Required(ErrorMessage = "Emri eshte i nevojshem!")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Mbiemri eshte i nevojshem!")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Emertimi eshte i nevojshem!")]
        public string Emertimi { get; set; }
        [Required(ErrorMessage = "Numri i telefonit eshte i nevojshem!")]
        public int NrTelefonit { get; set; }
        [Required(ErrorMessage = "Adresa eshte e nevojshem!")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Qyteti eshte i nevojshem!")]
        public string Qyteti { get; set; }
        [Required(ErrorMessage = "Shteti eshte i nevojshem!")]
        public string Shteti { get; set; }
        public bool ERegjistruar { get; set; }
        public bool EDerguar { get; set; }
        public int Pagesa { get; set; }

        public DateTime InsertData { get; set; }
    }
}
