using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api;

public record CreateUserRequest(string Name);
public record CreateUserResponse(string Token, User user);

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    public AuthController()
    {
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserRequest request)
    {
        User user = new User(request.Name);

        var claims = new List<Claim>()
        {
            new Claim("id", user.Id),
            new Claim("name", user.Name)
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Security Key 1234567890"));

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return base.Ok(new CreateUserResponse(jwtToken, user));
    }
}