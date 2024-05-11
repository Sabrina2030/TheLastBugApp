using TheLastBug.Business.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TheLastBug.IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUsuarioService usuarioService;
        public ResourceOwnerPasswordValidator(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = usuarioService.UserExists(context.UserName, context.Password);
            if (user != null)
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.IsAdmin  == 1 ? "admin":"noadmin")
                };
                context.Result = new GrantValidationResult(user.Id.ToString(), "password", claims);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Usuario no encontrado o contraseña incorrecta.");
            return Task.FromResult(context.Result);
        }
    }
}
