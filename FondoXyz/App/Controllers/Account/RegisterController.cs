using System.Text.RegularExpressions;
using FondoXYZ.Mdoels;
using FondoXYZ.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FondoXYZ.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Creo una variable para mirar si el usuario ya existe y hacer la validación.
                var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.DocumentNumber == model.DocumentNumber || u.Email == model.Email); //Usamos el contexto de users ya que el usuario se creara en la tabla de identity AspNetUsers
                if(userExist != null)
                {
                    ModelState.AddModelError("", "Este número de documento o correo  ya existen.");
                    return View(model);
                }

                 if(!Regex.IsMatch(model.Password, @"^\d+$")) //Uso una expresión regular para decirle al usuario que solo se permiten números ^con este se inicia,\d este es que solo recibe digitos del 0 al 9. + uno o mas digitos, $ termina la cadena 
                {
                    ViewBag.ErrorMessage = "La contraseña debe contener solo números.";
                    return View(model);
                }
                User user = new()
                {
                    Email = model.Email,
                    UserName = model.Email,  //debo tener en cuenta que identity necesita un User con un dato que sea el mas importante (Por lo general es un correo pero para el aplicativo usare el numero de documento) del modelo {Tener en cuenta que lo cambie ya que en el layout se debe mostrar el correo del usuario}
                    DocumentNumber = model.DocumentNumber,
                    Name = model.FullName,
                    DateBirth = model.BirthDate,
                    DateRegistered = DateOnly.FromDateTime(DateTime.Now)
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false); // Esta linea es para que cuando el usuario se cree "Registre" vaya al index, sedes
                    _logger.LogWarning($"Usuarios Creado con exito: {user.Email}");
                    return RedirectToAction("Index", "Sedes");
                }

                _logger.LogWarning($"Usuario no encontrado: {result}");

                if (!ModelState.IsValid)
                {
                   foreach (var error in result.Errors)
                    {
                         ModelState.AddModelError("", error.Description);
                        _logger.LogWarning($"Error al crear el usuario: {error.Description}");
                    }
                }
            }
            return View(model);
        }
    }
}
