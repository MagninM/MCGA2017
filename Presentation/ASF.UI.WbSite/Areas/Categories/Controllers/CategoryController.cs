using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categories/Category
        public ActionResult Index()
        {
            var CP = new CategoryProcess();
            var lista = CP.SelectList();
            return View(lista);
        }

        // GET: Categories/Category
        public ActionResult Details(int Id)
        {
            var CP = new CategoryProcess();
            var Objeto = CP.Find(Id);
            return View(Objeto);
        }
    }
}