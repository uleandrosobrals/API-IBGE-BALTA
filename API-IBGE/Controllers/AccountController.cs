using API_IBGE.Entities.Dtos;
using API_IBGE.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_IBGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration, IAccountService accountService, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AccountController ::  Acessado em  : "
               + DateTime.Now.ToLongDateString();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            //verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var result = await _accountService.UserLoginAsync(userLogin);

            if (result)
            {
                var userToken = _tokenService.CreateToken(userLogin).Result;


                return Ok(new
                {
                    userName = userLogin.UserName,
                    token = _tokenService.CreateToken(userLogin).Result
                });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido....");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterDto userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var result = await _accountService.RegisterUserAsync(userRegister);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
