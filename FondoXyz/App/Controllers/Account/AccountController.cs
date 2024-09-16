using FondoXYZ.Mdoels;
using FondoXYZ.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FondoXyz.Controllers{
    public class AccountController : Controller{
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager){
            _signInManager = signInManager;
        }
        
        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model){
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.NumberDocument, model.Password, isPersistent:false, lockoutOnFailure:false); //No bloqueamos tras multiples intentos, no recordamos al usuario  
            if(result.Succeeded)
            {
                RedirectToAction("Index", "Sedes");
            }
            ModelState.AddModelError("", "El numero o la clave no son correctos");
            return View(model); //Mostramos los dataNotations del modelo 
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}