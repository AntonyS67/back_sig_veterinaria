namespace SIG_VETERINARIA.DTOs.Recetas
{
    public class RecetasListResponseDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public string indicaciones { get; set; }
        public string created_at { get; set; }
        public int paciente_id { get; set; }
        public string paciente { get; set; }
        public int totalRecords { get; set; }
    }
}
