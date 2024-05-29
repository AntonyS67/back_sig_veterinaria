namespace SIG_VETERINARIA.DTOs.Tratamientos
{
    public class ProductsTratamientoListResponseDTO
    {
        public int id { get; set; }
        public int tratamiento_id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public int totalRecords { get; set; }
    }
}
