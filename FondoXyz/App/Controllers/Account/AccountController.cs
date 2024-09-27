using FondoXYZ.Mdoels;
using FondoXYZ.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace FondoXyz.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //var user = await _userManager.FindByNameAsync(model.DocumentNumber); // este funciona, solo si tuviera el userName con el campo que quiero guardar que el documento, pero lo tengo con el correo para mostrarlo en la vista. puede funcionar en cualquier otro login que use un email para iniciar sesión
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.DocumentNumber == model.DocumentNumber); // pero para este login Podemos usar el orm para ayudarnos a buscar el documento del usuario y hacer la validación mas consisa
            if (user == null)
            {
                ModelState.AddModelError("", "el número de documento o contraseña no es valido");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync
            (user.UserName, //Usamos la carecterización del usuario (En este caso el documento => nos podemos dar cuenta de mirando el dato en el registro)
            model.Password,
            isPersistent: true,
            lockoutOnFailure: false); //No bloqueamos tras multiples intentos, no recordamos al usuario 

            if (result.Succeeded)
            {
                _logger.LogInformation($"El usuario {user.UserName} se ha logueado exitosamente");
                _logger.LogInformation($"El usuario {user.PasswordHash} se ha logueado exitosamente");

                return RedirectToAction("Index", "Sedes");
            }
            else
            {
                ModelState.AddModelError("", "El numero de documento o la clave no son correctos");
                _logger.LogInformation($"Ocurrio un error en el Inicio de sersión del usuario: {user.UserName}"); // Esto deberia mostrarme el documento del usuario, la idea es mirar que error tendre
                return View(model); //Mostramos los dataNotations del modelo 
            }

        }

        public async Task<IActionResult> Logout()
        {
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // return RedirectToAction("Login", "Account");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}