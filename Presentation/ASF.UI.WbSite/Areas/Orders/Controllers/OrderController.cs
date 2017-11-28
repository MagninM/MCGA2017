using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Areas.Orders.Controllers
{
    public class OrderController : Controller
    {
        // GET: Orders/Order
        public ActionResult Index()
        {
            var op = new OrderProcess();
            var lista = op.SelectList();
            return View(lista);
        }

        // GET: Orders/Details
        public ActionResult Details(int id)
        {
            var op = new OrderProcess();
            var order = op.Find(id);

            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(int cartid)
        {
            //Creamos una nueva Order
            var orderprecargada = new Order();

            //Traemos el ID del cliente por el aspnetuser
            var aspuser = User.Identity.GetUserId();
            var cp = new ClientProcess();
            var client = cp.FindByASPUSER(aspuser);

            //Traemos todos los CartItem por el CartId
            var cip = new CartItemProcess();
            var lista = cip.FindByCartId(cartid);
            var total = 0.0;
            var cant = 0;
            foreach (CartItem item in lista)
            {
                item.Price = item.Price * item.Quantity;
                total = total + item.Price;
                cant = cant + 1;
            }

            //Completamos la Order con la info del Cart

            orderprecargada.ClientId = client.Id;
            orderprecargada.OrderDate = DateTime.Now;
            orderprecargada.TotalPrice = total;
            orderprecargada.State = 1;
            orderprecargada.OrderNumber = cartid;
            orderprecargada.ItemCount = cant;

            //Guardamos el OrderNumber en una Cookie
            Response.Cookies["OrderNumber"].Value = cartid.ToString();
            

            //Insertamos la nueva Order
            var op = new OrderProcess();
            var ordercargada = new Order();
            ordercargada = op.Insert(orderprecargada);
            //op.Insert(orderprecargada);

            return RedirectToAction("Index", "OrderDetail", new { area = "OrderDetails" });
        }

        [HttpPost]
        // POST: Orders/Create
        public ActionResult Create(Order order)
        {
            var op = new OrderProcess();
            op.Insert(order);
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete
        public ActionResult Delete(int id)
        {
            var op = new OrderProcess();
            op.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit
        public ActionResult Edit(int id)
        {
            var op = new OrderProcess();
            var order = op.Find(id);

            return View(order);
        }

        [HttpPost]
        // POST: Orders/Edit
        public ActionResult Edit(Order order)
        {
            var op = new OrderProcess();
            op.Edit(order);
            return RedirectToAction("Index");
        }

    }
}