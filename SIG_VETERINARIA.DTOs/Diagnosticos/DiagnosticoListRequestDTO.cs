namespace SIG_VETERINARIA.DTOs.Diagnosticos
{
    public class DiagnosticoListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int consult_id { get; set; }
    }
}
