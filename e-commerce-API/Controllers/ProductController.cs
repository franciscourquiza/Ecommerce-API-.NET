using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
