using ApiGestionDeudas.Api.DTOS;
using ApiGestionDeudas.Application.Interfaces;
using ApiGestionDeudas.Domain.Entities;
using ApiGestionDeudas.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionDeudas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosController(IUsuarioService usuarioService, 
            IAuth auth,
            IDeudaService deudaService
            
            )
        {
            UsuarioService = usuarioService;
            Auth = auth;
            DeudaService = deudaService;
        }

        public IUsuarioService UsuarioService { get; }
        public IAuth Auth { get; }
        public IDeudaService DeudaService { get; }

        [HttpPost]
        [Route("loginusuario")]
        public async Task<IActionResult> LoginUsuario([FromBody]Usuarios usuario)
        {
            try
            {
                var RespuestaUsuario = await UsuarioService.ValidarUsuario(usuario);
                if (RespuestaUsuario == null)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = "No autorizado",
                        data = (object?)null
                    });
                }

                var RespuestaDeudas = await DeudaService.GetDeudasPorUsuario(RespuestaUsuario.Id.ToString());

                var generateToken = Auth.GenerateToken(usuario.Email);
                var responseDto = new ResponseUsuarioDto
                {
                    Token = generateToken,
                    IdUsuario = RespuestaUsuario.Id,
                    Email = RespuestaUsuario.Email
                };

                return Ok(new
                {
                    success = true,
                    message = "Correcto",
                    data = responseDto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error haciendo login : " + ex.Message,
                    data = (object?)null
                });
            }
        }

        [HttpPost]
        [Route("InsertUsuario")]
        public async Task<ActionResult> InsertUsuario(Usuarios usuario)
        {
            try
            {

                var RespuestaInsertUsuario = await UsuarioService.InsertUsuario(usuario);
                if (RespuestaInsertUsuario == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Error insertando usuario",
                        data = (object?)null
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Correcto",
                    data = RespuestaInsertUsuario
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error insertando el usuario : " + ex.Message,
                    data = (object?)null
                });
            }
        }
    }
}
