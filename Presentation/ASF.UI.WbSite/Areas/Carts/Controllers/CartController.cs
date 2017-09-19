using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Carts.Controllers
{
    public class CartController : Controller
    {
        // GET: Carts/Cart
        public ActionResult Index()
        {
            var cp = new CartProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        // GET: Carts/Details
        public ActionResult Details(int id)
        {
            var cp = new CartProcess();
            var cart = cp.Find(id);

            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Carts/Create
        public ActionResult Create(Cart cart)
        {
            var cp = new CartProcess();
            cp.Insert(cart);
            return RedirectToAction("Index");
        }

        // GET: Carts/Delete
        public ActionResult Delete(int id)
        {
            var cp = new CartProcess();
            cp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Carts/Edit
        public ActionResult Edit(int id)
        {
            var cp = new CartProcess();
            var cart = cp.Find(id);

            return View(cart);
        }

        [HttpPost]
        // POST: Carts/Edit
        public ActionResult Edit(Cart cart)
        {
            var cp = new CartProcess();
            cp.Edit(cart);
            return RedirectToAction("Index");
        }
    }
}