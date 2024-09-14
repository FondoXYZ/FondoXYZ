using Microsoft.AspNetCore.Mvc;

namespace FondoXYZ.Controllers{
    public class SedesController : Controller{
       
        public IActionResult Index(){
            return View();
        }
    }
}