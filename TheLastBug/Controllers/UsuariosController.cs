using TheLastBug.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioService usuariosService;

        public UsuariosController(IConfiguration configuration, IUsuarioService usuariosService) : base(configuration)
        {
            this.usuariosService = usuariosService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAccount([FromBody] UsuarioDTO userAccount) => Ok(await usuariosService.CreateUserAccount(userAccount));

    }
}
