﻿using AuthAPI.Models.DTO;

namespace AuthAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<string?> Register (RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login (LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
