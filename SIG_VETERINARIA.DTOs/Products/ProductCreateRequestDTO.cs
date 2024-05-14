using Microsoft.AspNetCore.Http;

namespace SIG_VETERINARIA.DTOs.Products
{
    public class ProductCreateRequestDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string proveedor { get; set; }
        public string status_product { get; set; }
        public int category_id { get; set; }
        public IFormFile? photo { get; set; }
        public string? public_id { get; set; } = string.Empty;
        public string? uri_photo { get; set; } = string.Empty;
    }
}
