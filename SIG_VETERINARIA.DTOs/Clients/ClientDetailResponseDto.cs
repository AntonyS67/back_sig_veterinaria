namespace SIG_VETERINARIA.DTOs.Clients
{
    public class ClientDetailResponseDto
    {
        public int id { get; set; }
        public string names { get; set; }
        public string lastnames { get; set; }
        public string photo { get; set; }
        public string document_number { get; set; }
        public string document_type { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string public_id { get; set; }
        public string signature { get; set; }
    }
}
