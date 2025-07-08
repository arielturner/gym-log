using GymLog.UI.Models;
using GymLog.UI.Services;
using GymLog.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.UI.Controllers
{
    public class ExerciseCategoriesController : Controller
    {
        private readonly IExerciseCategoriesService _exerciseCategoriesService;

        public ExerciseCategoriesController(IExerciseCategoriesService exerciseCategoriesService)
        {
            _exerciseCategoriesService = exerciseCategoriesService;
        }

        public IActionResult Index()
        {
            var categories = _exerciseCategoriesService.GetAllExerciseCategories();
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _exerciseCategoriesService.DeleteExerciseCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["DeleteError"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var category = _exerciseCategoriesService.GetExerciseCategoryById(id);
            return View("CreateOrEdit", category);
        }

        public IActionResult Create()
        {
            return View("CreateOrEdit", new ExerciseCategory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveExerciseCategory(ExerciseCategory exerciseCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", exerciseCategory);
            }

            string userName = User.Identity?.Name?.StripDomain() ?? "unknown";
            exerciseCategory.UpdatedBy = userName;

            if (exerciseCategory.ExerciseCategoryId == 0)
            {
                exerciseCategory.CreatedBy = userName;
                _exerciseCategoriesService.CreateExerciseCategory(exerciseCategory);
            }
            else
            {
                _exerciseCategoriesService.UpdateExerciseCategory(exerciseCategory);
            }

            return RedirectToAction("Index");
        }
    }
}
