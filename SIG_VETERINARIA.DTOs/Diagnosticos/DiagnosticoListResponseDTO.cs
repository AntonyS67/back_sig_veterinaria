namespace SIG_VETERINARIA.DTOs.Diagnosticos
{
    public class DiagnosticoListResponseDTO
    {
        public int id { get; set; }
        public string detalle { get; set; }
        public string fecha_diagnostico { get; set; }
        public int totalRecords { get; set; }
    }
}
