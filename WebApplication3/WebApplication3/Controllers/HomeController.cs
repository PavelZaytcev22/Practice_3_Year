using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// 
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
