using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using TheLastBug.Business.DTOs;
using TheLastBug.Business.Interfaces;
using TheLastBug.Business.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using TheLastBug.Domain.Models;
using TheLastBug.Business.Helpers;
using Serilog;

namespace TheLastBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyudaSocialController : BaseController
    {
        private readonly IAyudaSocialService _ayudaSocialService;

        public AyudaSocialController(IConfiguration configuration, IAyudaSocialService ayudaSocialService) : base(configuration)
        {
            this._ayudaSocialService = ayudaSocialService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<int>> CreateAyudaSocial(AyudaSocialDTO ayudaSocialDto)
        {
            try
            {
                var ayudaSocialId = await _ayudaSocialService.CreateAyudaSocial(ayudaSocialDto);
                return CreatedAtAction(nameof(CreateAyudaSocial), ayudaSocialId);
            }
            catch (AyudaSocialAssignmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPost("createForRegion")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<int>> CreateAyudaSocialForRegion(AyudaSocialForRegionDTO ayudaSocialDto)
        {
            try
            {
                var ayudaSocialId = await _ayudaSocialService.CreateAyudaSocialForRegion(ayudaSocialDto);
                return CreatedAtAction(nameof(CreateAyudaSocialForRegion), ayudaSocialId);
            }
            catch (AyudaSocialAssignmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("usuariosConAyudas")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<List<UsuariosConAyudasDTO>>> GetUsuariosConAyudas()
        {
            var usuariosConAyudas = await _ayudaSocialService.GetUsuariosConAyudas();
            return Ok(usuariosConAyudas);
        }

        [HttpGet("byUsuario/{usuarioId}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<List<AyudaSocialDTO>>> GetAyudasSocialesByUsuario(int usuarioId)
        {
            var ayudasSociales = await _ayudaSocialService.GetAyudasSocialesByUsuario(usuarioId);
            return Ok(ayudasSociales);
        }

        [HttpGet("porUsuarioYAnio/{usuarioId}/{anio}")]
        public async Task<ActionResult<(List<AyudaSocialDTO>, AyudaSocialDTO)>> GetAyudasSocialesPorPersonaYAnio(int usuarioId)
        {
            var result = await _ayudaSocialService.GetAyudasSocialesByUsuarioByOrder(usuarioId);
            return Ok(result);
        }
    }
}