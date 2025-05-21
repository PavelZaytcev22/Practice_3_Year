using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер всего приложения
    /// </summary>
    [ApiController]
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns> </returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
