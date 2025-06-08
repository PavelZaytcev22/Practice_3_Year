using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для авторизации 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController:ControllerBase
    {
        private IConfiguration configuration;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="configuration">Конфигурация web приложения </param>
        public AuthorizationController(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Метод для получения jwt токена
        /// </summary>
        /// <param name="username">Имя пользователя для jwt токена</param>
        /// <returns>Асинхронная операция, которая возвращает строку с wt токеном</returns>
        [HttpGet("login/{username}")]
        public async Task<string> Login(string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:Minutes"])),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256)        
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
