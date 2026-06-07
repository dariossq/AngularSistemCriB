using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemCri.API.Controllers
{
    public class MunicipioeController : Controller
    {
        // GET: MunicipioeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MunicipioeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MunicipioeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MunicipioeController/Create
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

        // GET: MunicipioeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunicipioeController/Edit/5
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

        // GET: MunicipioeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunicipioeController/Delete/5
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
