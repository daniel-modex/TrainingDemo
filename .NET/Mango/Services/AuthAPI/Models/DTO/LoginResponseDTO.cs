﻿namespace AuthAPI.Models.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO? User { get; set; } = null;
        public string? Token { get; set; } = null;
    }
}
