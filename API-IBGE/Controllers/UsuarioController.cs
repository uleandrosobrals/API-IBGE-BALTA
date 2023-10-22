using API_IBGE.Data.DTO;
using API_IBGE.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_IBGE.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService UsuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        UsuarioService = usuarioService;
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> Cadastrausuario(CreateUsuarioDTO usuarioDTO)
    {

        await UsuarioService.Cadastra(usuarioDTO);
        return Ok("usuario cadastrado");

    }
    [HttpPost("login")]

    public async Task<IActionResult> LoginAsync(LoginUsuarioDTO dto)
    {
        var token = await UsuarioService.Login(dto);
        return Ok(token);
    }
}
