namespace SIG_VETERINARIA.DTOs.Consults
{
    public class ConsultListResponseDTO
    {
        public int id { get; set; }
        public string consult_date { get; set; }
        public string reason { get; set; }
        public string antecedents { get; set; }
        public string diseases { get; set; }
        public string next_consult { get; set; }
        public int patient_id { get; set; }
        public int totalRecords { get; set; }
    }
}
