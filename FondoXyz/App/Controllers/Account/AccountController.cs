using FondoXYZ.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FondoXyz.Controllers{
    public class AccountController : Controller{
        public IActionResult Login ()
        {
            return View();
        }
    }
}