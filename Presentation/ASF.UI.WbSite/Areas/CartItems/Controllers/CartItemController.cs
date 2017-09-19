using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.CartItems.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItems/CartItem
        public ActionResult Index()
        {
            var cp = new CartItemProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        // GET: CartsItem/Details
        public ActionResult Details(int id)
        {
            var cp = new CartItemProcess();
            var cartItem = cp.Find(id);

            return View(cartItem);
        }

        // GET: CartsItem/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: CartsItem/Create
        public ActionResult Create(CartItem cartItem)
        {
            var cp = new CartItemProcess();
            cp.Insert(cartItem);
            return RedirectToAction("Index");
        }

        // GET: CartsItem/Delete
        public ActionResult Delete(int id)
        {
            var cp = new CartItemProcess();
            cp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: CartsItem/Edit
        public ActionResult Edit(int id)
        {
            var cp = new CartItemProcess();
            var cartItem = cp.Find(id);

            return View(cartItem);
        }

        [HttpPost]
        // POST: CartsItem/Edit
        public ActionResult Edit(CartItem cartItem)
        {
            var cp = new CartItemProcess();
            cp.Edit(cartItem);
            return RedirectToAction("Index");
        }

    }
}