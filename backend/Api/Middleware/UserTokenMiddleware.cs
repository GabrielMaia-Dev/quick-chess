using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application;

namespace Api;

public class UserTokenMiddleware : IMiddleware
{
    public UserTokenMiddleware()
    {
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Query["access_token"].FirstOrDefault();

        if(token is null) 
        {
            context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return;
        }

        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);

        var name = jwtSecurityToken.Claims.First(c => c.Type == "name").Value;
        var id = jwtSecurityToken.Claims.First(c => c.Type == "id").Value;
        
        context.SetUsuario(new User(name, id));

        await next.Invoke(context);
    }
}
