using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Dealers.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealers/Dealer
        public ActionResult Index()
        {
            var dp = new DealerProcess();
            var lista = dp.SelectList();

            var cp = new CountryProcess();
            var listaCountry = cp.SelectList();
            ViewData["Country"] = listaCountry;

            var cp2 = new CategoryProcess();
            var listaCategory = cp2.SelectList();
            ViewData["Category"] = listaCategory;

            return View(lista);
        }

        // GET: Dealers/Details
        public ActionResult Details(int id)
        {
            var dp = new DealerProcess();
            var dealer = dp.Find(id);

            var cp = new CountryProcess();
            var descCountry = cp.Find(dealer.CountryId);
            ViewData["Country"] = descCountry.Name;

            var cp2 = new CategoryProcess();
            var descCategory = cp2.Find(dealer.CategoryId);
            ViewData["Category"] = descCategory.Name;

            return View(dealer);
        }

        // GET: Dealers/Create
        public ActionResult Create()
        {
            var cp = new CountryProcess();
            var listaCountry = cp.SelectList();
            ViewData["Country"] = listaCountry;

            var cp2 = new CategoryProcess();
            var listaCategory = cp2.SelectList();
            ViewData["Category"] = listaCategory;

            return View();
        }

        [HttpPost]
        // POST: Dealers/Create
        public ActionResult Create(Dealer dealer)
        {
            var dp = new DealerProcess();
            dp.Insert(dealer);
            return RedirectToAction("Index");
        }

        // GET: Dealers/Delete
        public ActionResult Delete(int id)
        {
            var cp = new DealerProcess();
            cp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Dealers/Edit
        public ActionResult Edit(int id)
        {
            var dp = new DealerProcess();
            var dealer = dp.Find(id);

            var cp = new CountryProcess();
            var listaCountry = cp.SelectList();
            ViewData["Country"] = listaCountry;

            var cp2 = new CategoryProcess();
            var listaCategory = cp2.SelectList();
            ViewData["Category"] = listaCategory;

            return View(dealer);
        }

        [HttpPost]
        // POST: Dealers/Edit
        public ActionResult Edit(Dealer dealer)
        {
            var dp = new DealerProcess();
            dp.Edit(dealer);
            return RedirectToAction("Index");
        }
    }
}