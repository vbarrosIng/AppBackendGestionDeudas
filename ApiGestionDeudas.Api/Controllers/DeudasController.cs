using ApiGestionDeudas.Application;
using ApiGestionDeudas.Application.Interfaces;
using ApiGestionDeudas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionDeudas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudasController : ControllerBase
    {
        public DeudasController(IDeudaService deudaService)
        {
            DeudaService = deudaService;
        }

        public IDeudaService DeudaService { get; }

        [HttpPost]
        [Route("insertdeuda")]
        public async Task<IActionResult> InsertDeuda([FromBody]Deudas deuda)
        {
            try
            {
                if (deuda.Total < 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "El valor de la deuda no puede ser menor a 0",
                        data = (object?)null
                    });
                }

                var RespuestaInsertService = await DeudaService.InsertDedua(deuda);

                return Ok(new
                {
                    success = true,
                    message = "Deuda creada",
                    data = RespuestaInsertService
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error insertando la deuda : " + ex.Message,
                    data = (object?)null
                });
            }
        }

        [HttpPost]
        [Route("UpdateDeuda")]
        public async Task<IActionResult> UpdateDeuda(Deudas deuda)
        {
            try
            {
                var RespuestaDeuda = await DeudaService.UpdateDeuda(deuda);

                if (!RespuestaDeuda)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "No existe la deuda o es posible actualizarla :  " + deuda.Id,
                        data = (object?)null
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Deuda actualizada",
                    data = RespuestaDeuda
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error actualizando la deuda :  " + ex.Message,
                    data = (object?)null
                });
            }
        }

        [HttpGet]
        [Route("GetDeudas/{IdUsuario}")]
        public async Task<IActionResult> GetDeudas(string IdUsuario)
        {
            try
            {

                var RespuestaInsertService = await DeudaService.GetDeudas(IdUsuario);

                return Ok(new
                {
                    success = true,
                    message = "Correcto",
                    data = RespuestaInsertService
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error obteniendo deudas : " + ex.Message,
                    data = (object?)null
                });
            }
        }

        [HttpGet]
        [Route("GetDeudaPorUsuario{IdUsuario}")]
        public async Task<IActionResult> GetDeudasPorUsuario(string IdUsuario)
        {
            try
            {

                var RespuestaDeudaUsuario = await DeudaService.GetDeudasPorUsuario(IdUsuario);

                return Ok(new
                {
                    success = true,
                    message = "Correcto",
                    data = RespuestaDeudaUsuario
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error obteniendo deudas : " + ex.Message,
                    data = (object?)null
                });
            }
        }
    }
}
