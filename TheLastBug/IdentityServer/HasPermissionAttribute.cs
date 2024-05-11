using Microsoft.AspNetCore.Authorization;
using System;
using TheLastBug.Business.Enums;

namespace TheLastBug.IdentityServer
{
    [AttributeUsage(AttributeTargets.Method
    | AttributeTargets.Class, Inherited = false)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(PermissionsEnum permission)
           : base(permission.ToString()) { }
    }
}
