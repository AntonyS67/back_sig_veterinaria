namespace SIG_VETERINARIA.DTOs.Diagnosticos
{
    public class DiagnosticoCreateRequestDTO
    {
        public int id { get; set; }
        public string detalle { get; set; }
        public DateTime fecha_diagnostico { get; set; }
        public int consult_id { get; set; }
    }
}
