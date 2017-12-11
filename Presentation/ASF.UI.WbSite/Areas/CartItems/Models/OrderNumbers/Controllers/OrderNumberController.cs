using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.OrderNumbers.Controllers
{
    public class OrderNumberController : Controller
    {
        // GET: OrderNumbers/OrderNumber
        public ActionResult Index()
        {
            var op = new OrderNumberProcess();
            var lista = op.SelectList();
            return View(lista);
        }

        // GET: OrderNumbers/Details
        public ActionResult Details(int id)
        {
            var op = new OrderNumberProcess();
            var orderNumber = op.Find(id);

            return View(orderNumber);
        }

        // GET: OrderNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: OrderNumbers/Create
        public ActionResult Create(OrderNumber orderNumber)
        {
            var op = new OrderNumberProcess();
            op.Insert(orderNumber);
            return RedirectToAction("Index");
        }

        // GET: OrderNumbers/Delete
        public ActionResult Delete(int id)
        {
            var op = new OrderNumberProcess();
            op.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: OrderNumbers/Edit
        public ActionResult Edit(int id)
        {
            var op = new OrderNumberProcess();
            var orderNumber = op.Find(id);

            return View(orderNumber);
        }

        [HttpPost]
        // POST: OrderNumbers/Edit
        public ActionResult Edit(OrderNumber orderNumber)
        {
            var op = new OrderNumberProcess();
            op.Edit(orderNumber);
            return RedirectToAction("Index");
        }

    }
}