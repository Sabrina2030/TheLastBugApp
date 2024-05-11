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
    public class RegionController : BaseController
    {
        private readonly IRegionService _regionService;
        private readonly IUsuarioService _usuarioService;

        public RegionController(IConfiguration configuration, IRegionService regionService, IUsuarioService usuarioService) : base(configuration)
        {
            this._regionService = regionService;
            this._usuarioService = usuarioService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<int>> CreateRegion([FromBody] RegionDTO regionDto)
        {
            var regionId = await _regionService.CreateRegion(regionDto);
            return CreatedAtAction(nameof(CreateRegion), regionId);
        }

        [HttpGet]
        public async Task<ActionResult<List<RegionDTO>>> GetAllRegiones()
        {
            var regiones = await _regionService.GetAllRegiones();
            return Ok(regiones);
        }

        [HttpGet("{regionId}")]
        public async Task<IActionResult> GetRegionById(int regionId)
        {
            var region = await _regionService.GetRegionById(regionId);

            if (region == null)
            {
                return NotFound($"No se encontró la región con ID: {regionId}");
            }

            return Ok(region);
        }

        [HttpDelete("{regionId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRegion(int regionId)
        {
            var success = await _regionService.DeleteRegion(regionId);

            if (!success)
            {
                return NotFound($"No se encontró la región con ID: {regionId}");
            }

            return Ok(success);
        }

        [HttpPut("{regionId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRegion(int regionId, [FromBody] RegionDTO regionDto)
        {
            var success = await _regionService.UpdateRegion(regionId, regionDto);

            if (!success)
            {
                return NotFound($"No se encontró la región con ID: {regionId}");
            }

            return CreatedAtAction(nameof(UpdateRegion), success);
        }
    }
}
