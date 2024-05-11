using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;
using TheLastBug.Business.Interfaces;

namespace TheLastBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : BaseController
    {
        private readonly IComunaService _comunaService;

        public ComunaController(IConfiguration configuration, IComunaService comunaService) : base(configuration)
        {
            this._comunaService = comunaService;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<int>> CreateComuna([FromBody] ComunaDTO comunaDto)
        {
            var comunaId = await _comunaService.CreateComuna(comunaDto);
            return CreatedAtAction(nameof(CreateComuna), comunaId);
        }

        [HttpGet]
        public async Task<ActionResult<List<ComunaDTO>>> GetAllComunas()
        {
            var comunas = await _comunaService.GetAllComunas();
            return Ok(comunas);
        }

        [HttpGet("{comunaId}")]
        public async Task<IActionResult> GetComunaById(int comunaId)
        {
            var comuna = await _comunaService.GetComunaById(comunaId);

            if (comuna == null)
            {
                return NotFound($"No se encontró la comuna con ID: {comunaId}");
            }

            return Ok(comuna);
        }

        [HttpDelete("{comunaId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteComuna(int comunaId)
        {
            var success = await _comunaService.DeleteComuna(comunaId);

            if (!success)
            {
                return NotFound($"No se encontró la comuna con ID: {comunaId}");
            }

            return Ok(success);
        }

        [HttpPut("{comunaId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateComuna(int comunaId, [FromBody] ComunaDTO comunaDto)
        {
            var success = await _comunaService.UpdateComuna(comunaId, comunaDto);

            if (!success)
            {
                return NotFound($"No se encontró la comuna con ID: {comunaId}");
            }

            return CreatedAtAction(nameof(UpdateComuna), success);
        }
    }
}
