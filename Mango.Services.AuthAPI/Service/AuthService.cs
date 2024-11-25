using Mango.Services.Auth.API.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IAuthService
    {
        public Task<LoginResponseDto> Login(LoginResponseDto loginResponseDto)
        {
            throw new NotImplementedException();
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
