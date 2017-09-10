using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categories/Category/Index
        public ActionResult Index()
        {
            var CP = new CategoryProcess();
            var lista = CP.SelectList();
            return View(lista);
        }

        // GET: Categories/Category/Details
        public ActionResult Details(int Id)
        {
            var CP = new CategoryProcess();
            var Objeto = CP.Find(Id);
            return View(Objeto);
        }

        // GET: Categories/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categories/Category/Create
        [HttpPost]
        public ActionResult Create(Category CAT)
        {
            var CP = new CategoryProcess();
            CP.Insert(CAT);
            return RedirectToAction("Index");
        }

        // GET: Categories/Category/Edit
        public ActionResult Edit(int Id)
        {
            var CP = new CategoryProcess();
            var Objeto = CP.Find(Id);
            return View(Objeto);
        }

        //POST: Categories/Category/Edit
        [HttpPost]
        public ActionResult Edit(Category CAT)
        {
            var CP = new CategoryProcess();
            CP.Edit(CAT);
            return RedirectToAction("Index");
        }

        // GET: Categories/Category/Delete
        public ActionResult Delete(int Id)
        {
            var CP = new CategoryProcess();
            CP.Delete(Id);
            return RedirectToAction("Index");
        }

        ////POST: Categories/Category/Delete
        //[HttpPost]
        //public ActionResult Delete(Category CAT)
        //{
        //    var CP = new CategoryProcess();
        //    CP.Insert(CAT);
        //    return RedirectToAction("Index");
        //}

    }
}