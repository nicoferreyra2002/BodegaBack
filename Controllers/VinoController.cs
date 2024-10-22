using Bodega.Dtos;
using Bodega.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bodega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VinoController: ControllerBase
    {
        private readonly IVinoService _vinoService;

        public VinoController(IVinoService vinoService)
        {
            _vinoService = vinoService;
        }

        [HttpGet]
        public IActionResult GetVinos()
        {
            try
            {
                var vinos = _vinoService.GetAllVinos();
                return Ok(vinos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los vinos: {ex.Message}");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetVinoByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return BadRequest("El nombre no puede estar vacío.");

                var vino = _vinoService.GetVinoByName(name);

                if (vino == null)
                    return NotFound($"No se encontró el vino '{name}'.");

                return Ok(vino);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el vino: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult RegisterVino([FromBody] VinoDtos vinoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _vinoService.RegisterVino(vinoDto);
                return Ok("Vino registrado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el vino: {ex.Message}");
            }
        }

        [HttpPut("addstock/{name}")]
        public IActionResult AddStock(string name, [FromBody] int quantity)
        {
            try
            {
                if (quantity < 0)
                    return BadRequest("La cantidad debe ser positiva.");

                _vinoService.AddStock(name, quantity);
                return Ok($"Se agregó {quantity} unidades al stock del vino '{name}'.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el stock: {ex.Message}");
            }
        }
    }
}
