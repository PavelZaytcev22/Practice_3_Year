using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Settings;
using Microsoft.Extensions.Options;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для авторизации 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController:ControllerBase
    {
        private JwtSettings settings;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="settings">Настройки для jwt токена полученные с помощью сервиса IOptions</param>
        public AuthorizationController(IOptions<JwtSettings> settings) 
        {
            this.settings = settings.Value;
        }
        /// <summary>
        /// Метод для получения jwt токена
        /// </summary>
        /// <param name="username">Имя пользователя для jwt токена</param>
        /// <returns>Асинхронная операция, которая возвращает строку с wt токеном</returns>
        [HttpGet("login/{username}")]
        public async Task<string> Login(string username)
        {
            if (username.IsNullOrEmpty()) throw new ArgumentNullException();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(settings.Minutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)), SecurityAlgorithms.HmacSha256)        
            );
            return  new  JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
