using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.API.Infrastructure.Configuration;
using Services.Common.Dtos.User;
using Services.Domain.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services.API.Controllers;

[Route("api/account")]
public class AuthController : AppBaseController
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AuthOptions _authenticationOptions;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<AuthOptions> authenticationOptions)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authenticationOptions = authenticationOptions.Value;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetInfo()
    {
        var userName = User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
        return Ok(userName);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserAuthDto userAuthDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        User user = new User { UserName = userAuthDto.Username };

        var result = await _userManager.CreateAsync(user, userAuthDto.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return Ok(userAuthDto);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserAuthDto userAuthDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var identity = await GetIdentity(userAuthDto);

        if (identity == null)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var jwt = new JwtSecurityToken(
                            issuer: _authenticationOptions.Issuer,
                            audience: _authenticationOptions.Audience,
                            notBefore: DateTime.Now,
                            claims: identity.Claims,
                            expires: DateTime.Now.AddMonths(_authenticationOptions.TokenLifetime),
                            signingCredentials: new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt,
        };

        return Json(response);
    }
    private async Task<ClaimsIdentity?> GetIdentity(UserAuthDto userAuthDto)
    {
        var result =
                await _signInManager.PasswordSignInAsync(userAuthDto.Username, userAuthDto.Password, false, false);

        if (!result.Succeeded)
        {
            return null;
        }

        var user = await _userManager.FindByNameAsync(userAuthDto.Username);
        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
        }

        ClaimsIdentity claimsIdentity = new(claims, _authenticationOptions.SecretKey, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }
}
