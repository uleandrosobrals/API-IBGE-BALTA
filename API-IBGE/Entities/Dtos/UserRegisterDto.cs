namespace API_IBGE.Entities.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmePassword { get; set; }
        public string Role { get; set; } = "Admin";
    }
}
