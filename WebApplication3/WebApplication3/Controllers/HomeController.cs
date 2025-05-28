using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер приложения
    /// </summary>
    [Controller]
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

        public IActionResult Component()
        {
            return View();
        }
    }
}
