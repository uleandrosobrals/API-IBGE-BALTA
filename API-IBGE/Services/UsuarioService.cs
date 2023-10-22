using API_IBGE.Data.DTO;
using API_IBGE.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API_IBGE.Services
{
    public class UsuarioService
    {

        private IMapper Mapper;
        private UserManager<Usuario> UserManager;
        private SignInManager<Usuario> SignInManager;
        private AuthorizationService AuthiService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, AuthorizationService authiService)
        {
            Mapper = mapper;
            UserManager = userManager;
            SignInManager = signInManager;
            AuthiService = authiService;
        }
        public async Task Cadastra(CreateUsuarioDTO DTO)
        {
            Usuario usuario = Mapper.Map<Usuario>(DTO);

            IdentityResult resultado = await UserManager.CreateAsync(usuario, DTO.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha no cadastro de usuario");
        }

        internal async Task<string> Login(LoginUsuarioDTO dto)
        {
            var resultado = await SignInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            
            if (!resultado.Succeeded) throw new ApplicationException("Usuario não cadastrado ou senha ou email incorretos");

            //busca o usuario atraves do signInManager
            Usuario usuario = SignInManager.UserManager.Users.FirstOrDefault(usuario => usuario.UserName == dto.Username);

            var token = AuthiService.GenerateToken(usuario);
            return token;
        }
    }
}
