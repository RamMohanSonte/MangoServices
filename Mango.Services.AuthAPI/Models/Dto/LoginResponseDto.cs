namespace Mango.Services.AuthAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
    }
}
