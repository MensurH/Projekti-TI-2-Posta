namespace Projekti_TI_2_Posta.Application.Dtos.Porosia
{
    public class CreatePorosiaDto
    {
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
    }
}
