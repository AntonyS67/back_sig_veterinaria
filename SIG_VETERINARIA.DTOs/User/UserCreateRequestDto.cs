namespace SIG_VETERINARIA.DTOs.User
{
    public class UserCreateRequestDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
    }
}
