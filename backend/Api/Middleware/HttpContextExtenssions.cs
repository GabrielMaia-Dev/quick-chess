using Application;
using Microsoft.AspNetCore.Http;

namespace Api;

public static class HttpContextExtenssions
{
    public static void SetUsuario(this HttpContext context, User user)
    {
        context.Items["Usuario"] = user;
    }
    public static User GetUsuario(this HttpContext context)
    {
        return (context.Items["Usuario"] as User)!;
    }
}