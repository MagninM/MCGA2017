using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Areas.CartItems.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItems/CartItem
        [Authorize]
        public ActionResult Index()
        {
            var cookie = Request.Cookies[".AspNet.ApplicationCookie"].Value;
            var cp = new CartProcess();
            var cart = cp.Cookie(cookie);
            if (cart == null)
            {
                //VER QUE HACER CUANDO EL CARRITO NO EXISTE
                cart = new Cart();
                cart.Id = 0;
            }


            var cip = new CartItemProcess();
            var lista = cip.FindByCartId(cart.Id);
            var total = 0.0;
            var CantidadTotal = 0;
            foreach (CartItem item in lista)
            {
                item.Price = item.Price * item.Quantity;
                total = total + item.Price;
                CantidadTotal = CantidadTotal + item.Quantity;
            }
            ViewBag.Cantidad = CantidadTotal;
            ViewBag.total = total;
            ViewBag.cartid = cart.Id;
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
        [Authorize]
        public ActionResult Create(int id)
        {
            var cookie = Request.Cookies[".AspNet.ApplicationCookie"].Value;
            var cp = new CartProcess();
            var cart = cp.Cookie(cookie);
            if (cart == null)
            {
                cp.Insert(new Cart()
                {
                    CartDate = DateTime.Now,
                    Cookie = cookie
                });
                cart = cp.Cookie(cookie);
            }
            var pp = new ProductProcess();
            var prd = pp.Find(id);
            ViewBag.Descripcion = prd.Description;
            ViewBag.Nombre = prd.Title;
            ViewBag.Imagen = prd.Image;
            ViewBag.Precio = prd.Price;
            ViewBag.ProductId = id;

            var item = new CartItem();
            item.CartId = cart.Id;
            item.ProductId = id;
            item.Price = prd.Price;
            item.Quantity = 1;


            return View(item);
        }

        [HttpPost]
        // POST: CartsItem/Create
        public ActionResult Create(CartItem cartItem)
        {
            var cp = new CartItemProcess();
            cp.Insert(cartItem);
            return RedirectToAction("ProductList","Product", new { area = "Products" });
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