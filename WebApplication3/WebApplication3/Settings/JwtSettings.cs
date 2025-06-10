using Microsoft.Extensions.Options;

namespace WebApplication3.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Minutes { get; set; }
    }
}
