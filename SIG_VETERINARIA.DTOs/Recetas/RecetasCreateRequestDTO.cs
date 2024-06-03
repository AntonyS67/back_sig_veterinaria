namespace SIG_VETERINARIA.DTOs.Recetas
{
    public class RecetasCreateRequestDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public string indicaciones { get; set; }
        public int paciente_id { get; set; }
    }
}
