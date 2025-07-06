using GymLog.UI.Models;
using GymLog.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.UI.Controllers
{
    public class BodyPartsController : Controller
    {
        private readonly IBodyPartsService _bodyPartsService;

        public BodyPartsController(IBodyPartsService bodyPartsService)
        {
            _bodyPartsService = bodyPartsService;
        }

        public IActionResult Index()
        {
            var bodyParts = _bodyPartsService.GetAllBodyParts();
            return View(bodyParts);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _bodyPartsService.DeleteBodyPart(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message)
                ModelState.AddModelError("", ex.Message);
                return View("Index", _bodyPartsService.GetAllBodyParts());
            }
        }
    }
}
