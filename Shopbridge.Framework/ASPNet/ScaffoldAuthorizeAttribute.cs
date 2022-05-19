using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace Shopbridge.Framework.AspNetCore
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class ScaffoldAuthorizeAttribute : AuthorizeAttribute
    {
        public ScaffoldAuthorizeAttribute(params object[] roles) => Roles = string.Join(",", roles.Select(role => Enum.GetName(role.GetType(), role)));
    }
}