using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UnlaLibrary.UI.Web.Helper
{
    public class Authorization
    {

    }

    public class UserType : IAuthorizationRequirement
    {
        public int Tipo { get; set; }
        public UserType(int _Tipo)
        {
            Tipo = _Tipo;
        }
    }
    public class UserTypeHandler : AuthorizationHandler<UserType>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserType requirement)
        {
           
            if (!context.User.HasClaim(x => x.Type == "TipoDeUsuarioId"))
            {
                return Task.CompletedTask;
            }
            int tipo = Convert.ToInt32(context.User.FindFirst(x => x.Type == "TipoDeUsuarioId").Value);
            if (tipo == requirement.Tipo)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }

    }

}
