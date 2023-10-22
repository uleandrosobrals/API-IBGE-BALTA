using System.ComponentModel.DataAnnotations;

namespace API_IBGE.Data.DTO
{
    public class LoginUsuarioDTO
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
