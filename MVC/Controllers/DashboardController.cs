using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Dashboard;

namespace MVC.Controllers
{
    [Route("dashboard")]
    public class DashboardController : BaseController<DashboardController>
    {
        // GET: DashboardController
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View(new RegisterModel());
        }

        // GET: DashboardController/Details/5
        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(string id)
        {
            var model = new RegisterModel();
            model.Username = id;

            //TODO: Get user data from database

            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }
                
                return RedirectToAction(nameof(Details), new { id = model.Username });

            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        [HttpGet]
        [Route("edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
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

        // GET: DashboardController/Delete/5
        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
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
