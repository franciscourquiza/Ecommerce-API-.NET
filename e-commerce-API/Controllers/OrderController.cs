using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    public class OrderController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
