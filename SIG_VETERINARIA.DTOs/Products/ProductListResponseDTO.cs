namespace SIG_VETERINARIA.DTOs.Products
{
    public class ProductListResponseDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string proveedor { get; set; }
        public string status_product { get; set; }
        public int category_id { get; set; }
        public string photo { get; set; }
        public string public_id { get; set; }
        public string category { get; set; }
        public int totalRecords { get; set; }
    }
}
