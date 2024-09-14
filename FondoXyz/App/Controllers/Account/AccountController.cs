using Microsoft.AspNetCore.Mvc;

namespace FondoXyz.Controllers{
    public class AccountController : Controller{
        public IActionResult Login ()
        {
            return View();
        }
    }
}