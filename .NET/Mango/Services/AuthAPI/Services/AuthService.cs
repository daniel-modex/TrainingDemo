using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Models.DTO;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;
using AuthAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbcontext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        
        public AuthService(AppDbContext dbcontext, UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator, RoleManager<IdentityRole> roleManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _dbcontext.applicationUsers.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user,roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbcontext.applicationUsers.FirstOrDefault(x=>x.UserName.ToLower()==loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if(user==null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = string.Empty,
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDTO userDTO = new ()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            };
            LoginResponseDTO loginResponseDTO = new()
            {
                User = userDTO,
                Token = token,
            };
            return loginResponseDTO;
        }

        public async Task<string?> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                Name = registrationRequestDTO.Name,
                Email = registrationRequestDTO.Email,
                PhoneNumber = registrationRequestDTO.PhoneNumber,
                UserName = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper()
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _dbcontext.applicationUsers.First(x => x.UserName == registrationRequestDTO.Email);
                    if (userToReturn != null)
                    {
                        UserDTO userDTO = new()
                        {
                            Id = userToReturn.Id,
                            Email = userToReturn.Email,
                            Name = userToReturn.Name,
                            PhoneNumber = userToReturn.PhoneNumber
                        };
                        return string.Empty;
                    }
                }
                else
                {
                    return result.Errors?.FirstOrDefault()?.Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Error Encountered";
        }
    }
}
