using GymLog.UI.Models;
using GymLog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymLog.UI.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExercisesService _exerciseService;
        private readonly IBodyPartsService _bodyPartsService;
        private readonly IExerciseCategoriesService _exerciseCategoriesService;

        public ExercisesController(IExercisesService exerciseService, IBodyPartsService bodyPartsService, IExerciseCategoriesService exerciseCategoriesService)
        {
            _exerciseService = exerciseService;
            _bodyPartsService = bodyPartsService;
            _exerciseCategoriesService = exerciseCategoriesService;
        }

        public IActionResult Index()
        {
            var exercises = _exerciseService.GetAllExercises();
            return View(exercises);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _exerciseService.DeleteExercise(id);
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
            var exercise = _exerciseService.GetExerciseById(id);
            return RedirectToCreateOrEdit(exercise);
        }

        public IActionResult Create()
        {
            return RedirectToCreateOrEdit(new Exercise());
        }

        public IActionResult SaveExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToCreateOrEdit(exercise);
            }

            string userName = User.Identity?.Name ?? "unknown";
            exercise.UpdatedBy = userName;

            if (exercise.ExerciseId == 0)
            {
                exercise.CreatedBy = userName;
                _exerciseService.CreateExercise(exercise);
            }
            else
            {
                _exerciseService.UpdateExercise(exercise);
            }

            return RedirectToAction("Index");
        }

        private IActionResult RedirectToCreateOrEdit(Exercise exercise)
        {
            var bodyParts = _bodyPartsService.GetAllBodyParts();
            var exerciseCategories = _exerciseCategoriesService.GetAllExerciseCategories();

            var defaultListItem = new SelectListItem("<--- Select --->", null);

            var bodyPartsSelectList = new SelectList(bodyParts, "BodyPartId", "BodyPartName");
            ViewBag.BodyParts = bodyPartsSelectList.Prepend(defaultListItem);

            var exerciseCategoriesSelectList = new SelectList(exerciseCategories, "ExerciseCategoryId", "ExerciseCategoryName");
            ViewBag.ExerciseCategories = exerciseCategoriesSelectList.Prepend(defaultListItem);

            return View("CreateOrEdit", exercise);
        }
    }
}
