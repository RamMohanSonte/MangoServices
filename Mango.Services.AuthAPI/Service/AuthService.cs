using Mango.Services.Auth.API.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IAuthService
    {
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = db.ApplicationUses.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.Username);
            var isValid = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || isValid==false) {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            UserDto userDto = new()
            {
                Email=user.Email,
                ID  = user.Id,  
                Name = user.Name,
                PhoneNumber=user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token=""
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                Email = registrationRequestDto.Email,
                Name = registrationRequestDto.Name,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber,
                UserName = registrationRequestDto.Email
            };
            try
            {
                var result=await userManager.CreateAsync(user,registrationRequestDto.Password);
                if (result.Succeeded) { 
                    var userToReturn=db.ApplicationUses.First(u=>u.UserName == registrationRequestDto.Email);
                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber= userToReturn.PhoneNumber
                    };
                    return "";
                }
                return result.Errors.FirstOrDefault().Description;
            }
            catch (Exception ex)
            {
            }
            return "Some Error Occured";
        }
    }
}
