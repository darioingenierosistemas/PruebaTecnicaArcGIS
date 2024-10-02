using ArcGISApi.DTO;
using ArcGISApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcGISApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MejoraConstruccionController : ControllerBase
    {
        private readonly IArcGISService _arcGISService;
        private readonly IJwtAuthService _jwtAuthService;

        public MejoraConstruccionController(IArcGISService arcGISService, IJwtAuthService jwtAuthService)
        {
            _arcGISService = arcGISService;
            _jwtAuthService = jwtAuthService;
        }

        // Endpoint para editar una mejora
        // Endpoint para editar una mejora
        [HttpPost("mejora/{id}")]
        [Authorize]
        public async Task<IActionResult> EditarMejora(string id, [FromBody] MejoraDTO mejoraDto)
        {
            try
            {
                if (!await _jwtAuthService.ValidateToken(HttpContext))
                {
                    return Unauthorized();
                }

                var resultado = await _arcGISService.UpdateMejora(id, mejoraDto);
                if (!resultado)
                {
                    return BadRequest("Error al actualizar la mejora.");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw; 
            }
        }


        // Endpoint para eliminar una mejora
        [HttpPost("mejora/eliminar/{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarMejora(string id)
        {
            if (!await _jwtAuthService.ValidateToken(HttpContext))
            {
                return Unauthorized();
            }

            var resultado = await _arcGISService.DeleteMejora(id);
            return Ok(resultado);
        }

        // Endpoint para editar una construcción
        [HttpPost("construccion/{id}")]
        [Authorize]
        public async Task<IActionResult> EditarConstruccion(string id, [FromBody] ConstruccionDTO construccionDto)
        {
            if (!await _jwtAuthService.ValidateToken(HttpContext))
            {
                return Unauthorized();
            }

            var resultado = await _arcGISService.UpdateConstruccion(id, construccionDto);
            return Ok(resultado);
        }

        // Endpoint para eliminar una construcción
        [HttpPost("construccion/eliminar/{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarConstruccion(string id)
        {
            if (!await _jwtAuthService.ValidateToken(HttpContext))
            {
                return Unauthorized();
            }

            var resultado = await _arcGISService.DeleteConstruccion(id);
            return Ok(resultado);
        }
    }
}
