namespace AuthAPI.Models.DTO
{
    public class RegistrationRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
