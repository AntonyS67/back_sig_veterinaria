namespace SIG_VETERINARIA.DTOs.Consults
{
    public class ConsultListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int patient_id { get; set; }
    }
}
