namespace Intranet.Services.AuthService.Models.DTO
{
    public class LoginDTO
    {
        // Хэрэглэгч UserName эсүүл Email 2-ийн аль нэгээр нэвтэрнэ 
        public required string UserIdentifier { get; set; }

        public required string Password { get; set; }
    }
}
