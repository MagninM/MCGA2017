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
            return View(lista);
        }

        // GET: Dealers/Details
        public ActionResult Details(int id)
        {
            var dp = new DealerProcess();
            var pais = dp.Find(id);

            return View(pais);
        }

        // GET: Dealers/Create
        public ActionResult Create()
        {
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