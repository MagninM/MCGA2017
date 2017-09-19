using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Countries.Controllers
{
    public class CountryController : Controller
    {
        // GET: Countries/Country
        public ActionResult Index()
        {
            var cp = new CountryProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        // GET: Countries/Details
        public ActionResult Details(int id)
        {
            var cp = new CountryProcess();
            var pais = cp.Find(id);

            return View(pais);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Countries/Create
        public ActionResult Create(Country pais)
        {
            var cp = new CountryProcess();
            cp.Insert(pais);
            return RedirectToAction("Index");
        }

        // GET: Countries/Delete
        public ActionResult Delete(int id)
        {
            var cp = new CountryProcess();
            cp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Countries/Edit
        public ActionResult Edit(int id)
        {
            var cp = new CountryProcess();
            var pais = cp.Find(id);

            return View(pais);
        }

        [HttpPost]
        // POST: Countries/Edit
        public ActionResult Edit(Country pais)
        {
            var cp = new CountryProcess();
            cp.Edit(pais);
            return RedirectToAction("Index");
        }
    }
}