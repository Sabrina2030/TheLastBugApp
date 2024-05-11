using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;
using TheLastBug.Business.Interfaces;
using TheLastBug.Business.Services;
using TheLastBug.Domain.Models;

namespace TheLastBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : BaseController
    {
        private readonly IPaisService _paisService;

        public PaisController(IConfiguration configuration, IPaisService paisService) : base(configuration)
        {
            this._paisService = paisService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<int>> CreatePais([FromBody] PaisDTO paisDto)
        {
            var paisId = await _paisService.CreatePais(paisDto);
            return CreatedAtAction(nameof(CreatePais), paisId);
        }

        [HttpGet]
        public async Task<ActionResult<List<PaisDTO>>> GetAllPaises()
        {
            var paises = await _paisService.GetAllPaises();
            return Ok(paises);
        }

        [HttpGet("{paisId}")]
        public async Task<IActionResult> GetPaisById(int paisId)
        {
            var pais = await _paisService.GetPaisById(paisId);

            if (pais == null)
            {
                return NotFound($"No se encontró el país con ID: {paisId}");
            }

            return Ok(pais);
        }

        [HttpDelete("{paisId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePais(int paisId)
        {
            var success = await _paisService.DeletePais(paisId);

            if (!success)
            {
                return NotFound($"No se encontró el país con ID: {paisId}");
            }

            return Ok(success);
        }

        [HttpPut("{paisId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePais(int paisId, [FromBody] PaisDTO paisDto)
        {
            var success = await _paisService.UpdatePais(paisId, paisDto);

            if (!success)
            {
                return NotFound($"No se encontró el país con ID: {paisId}");
            }

            return CreatedAtAction(nameof(UpdatePais), success);
        }
    }
}
