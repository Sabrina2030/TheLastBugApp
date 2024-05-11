using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TheLastBug.Business.DTOs;
using TheLastBug.Business.Interfaces;
using TheLastBug.Domain.Models;

namespace TheLastBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : BaseController
    {
        private readonly ILogService _logService;

        public LogController(IConfiguration configuration, ILogService logService) : base(configuration)
        {
            this._logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LogDTO>>> GetLogsByDate(DateTime fecha)
        {
            var logs = await _logService.GetLogsByDate(fecha);
            return Ok(logs);
        }
    }
}
