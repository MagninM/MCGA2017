using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Clients.Controllers
{
    public class ClientController : Controller
    {
        // GET: Clients/Client
        public ActionResult Index()
        {
            var cp = new ClientProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        // GET: Clients/Details
        public ActionResult Details(int id)
        {
            var cp = new ClientProcess();
            var client = cp.Find(id);

            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Clients/Create
        public ActionResult Create(Client client)
        {
            var cp = new ClientProcess();
            cp.Insert(client);
            return RedirectToAction("Index");
        }

        // GET: Clients/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ClientProcess();
            cp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Clients/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ClientProcess();
            var cat = cp.Find(id);

            return View(cat);
        }

        [HttpPost]
        // POST: Clients/Edit
        public ActionResult Edit(Client client)
        {
            var cp = new ClientProcess();
            cp.Edit(client);
            return RedirectToAction("Index");
        }

    }
}