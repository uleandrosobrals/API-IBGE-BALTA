using System.ComponentModel.DataAnnotations;

namespace API_IBGE.Data.DTO
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]//Mostra que essa propriedade aqui é uma senha
        public string Password { get; set; }

        [Required]
        [Compare("Password")]//Confirma se é igual a senha
        public string RePassword { get; set; }

    }
}
