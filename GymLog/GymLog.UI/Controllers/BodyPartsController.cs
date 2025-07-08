using GymLog.UI.Models;
using GymLog.UI.Services;
using GymLog.UI.Utilities;
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

            var bodyPart = _bodyPartsService.GetBodyPartById(id);
            return View("Edit", bodyPart);
        }

        public IActionResult SaveBodyPart(BodyPart bodyPart)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", bodyPart);
            }

            string userName = User.Identity?.Name?.StripDomain() ?? "unknown";
            bodyPart.UpdatedBy = userName;

            if (bodyPart.BodyPartId == 0)
            {
                bodyPart.CreatedBy = userName;
                _bodyPartsService.CreateBodyPart(bodyPart);
            }
            else
            {
                _bodyPartsService.UpdateBodyPart(bodyPart);
            }
                
            return RedirectToAction("Index");
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
                TempData["DeleteError"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
