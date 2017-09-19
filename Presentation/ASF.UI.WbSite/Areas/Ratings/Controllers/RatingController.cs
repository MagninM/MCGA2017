using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Ratings.Controllers
{
    public class RatingController : Controller
    {
        // GET: Ratings/Rating
        public ActionResult Index()
        {
            var rp = new RatingProcess();
            var lista = rp.SelectList();
            return View(lista);
        }

        // GET: Ratings/Details
        public ActionResult Details(int id)
        {
            var rp = new RatingProcess();
            var rtng = rp.Find(id);

            return View(rtng);
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Ratings/Create
        public ActionResult Create(Rating rating)
        {
            var rp = new RatingProcess();
            rp.Insert(rating);
            return RedirectToAction("Index");
        }

        // GET: Ratings/Delete
        public ActionResult Delete(int id)
        {
            var rp = new RatingProcess();
            rp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Ratings/Edit
        public ActionResult Edit(int id)
        {
            var rp = new RatingProcess();
            var rtng = rp.Find(id);

            return View(rtng);
        }

        [HttpPost]
        // POST: Ratings/Edit
        public ActionResult Edit(Rating rating)
        {
            var rp = new RatingProcess();
            rp.Edit(rating);
            return RedirectToAction("Index");
        }

    }
}