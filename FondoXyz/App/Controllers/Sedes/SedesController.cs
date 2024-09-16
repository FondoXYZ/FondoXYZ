using FondosXYZ.Models;
using FondosXYZ.Services;
using FondoXyz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FondoXYZ.Controllers{
    public class SedesController : Controller
    {
        private readonly ISedesRepository _sedesRepository;
        public SedesController(ISedesRepository sedesRepository)
        {
            _sedesRepository = sedesRepository;
        }
         [Authorize] //este es el guardian
        public async Task <IActionResult> Index()
        {
            try{
                var sedes = await _sedesRepository.GetAllSedes();
                return View(sedes);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Listamos por id 
        public async Task <IActionResult> Details (int id)
        {
            try{
                var sede = await _sedesRepository.GetSedeById(id);
                 if(sede == null){
                    return NotFound();
                }
                return View(sede);

            }catch(Exception ex){
                return NotFound();
            }
        }

        //Creamos una sede
        public async Task <IActionResult> Create ()
        {
            return View();
        }
        [HttpPost ]
        public async Task<IActionResult> Create (Sede sede)
        {
            try{
               if(ModelState.IsValid)
               {
                await _sedesRepository.AddSedeAsync(sede);
                return RedirectToAction(nameof(Index));
               }
               return View(sede);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        //Editamos sede 
        [HttpPost]
        public async Task <IActionResult> Edit (Sede sede)
        {
            try{
                if(ModelState.IsValid)
                {
                    await _sedesRepository.UpdateSedeAsync(sede);
                    return RedirectToAction(nameof(Index));
                }
                return View(sede);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        public async Task<IActionResult> Delete (int id)
        {
            var sede = await _sedesRepository.GetSedeById(id);
            {
                if(sede == null)
                {
                    return NotFound();
                }
                return View(sede);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        { 
            await _sedesRepository.DeleteSedeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
