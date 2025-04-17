using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.API.Controllers
{
    public class BodyPartController : Controller
    {
        // GET: BodyPartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BodyPartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BodyPartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyPartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BodyPartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BodyPartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BodyPartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BodyPartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
