using SIG_VETERINARIA.DTOs.User;

namespace SIG_VETERINARIA.DTOs.Auth
{
    public class AuthResponseDto
    {
        public Boolean IsSuccess { get; set; }
        public UserDetailResponseDto User { get; set; }
        public string Token { get; set; }
    }

    public class TokenResponseDto
    {
        public string Token { get; set; }
    }
}
