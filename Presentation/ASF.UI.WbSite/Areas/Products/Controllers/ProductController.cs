using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products/Product
        [Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            var pp = new ProductProcess();
            var lista = pp.SelectList();

            var dp = new DealerProcess();
            var listadealer = dp.SelectList();
            ViewData["Dealer"] = listadealer;

            return View(lista);
        }

        // GET: Products/Details
        [Authorize(Roles = "Administradores")]
        public ActionResult Details(int id)
        {
            var pp = new ProductProcess();
            var prd = pp.Find(id);

            var dp = new DealerProcess();
            var nameDealer = dp.Find(prd.DealerId);
            ViewData["Dealer"] = nameDealer.FirstName + " " + nameDealer.LastName;

            return View(prd);
        }

        // GET: Products/Create
        //[Authorize(Roles = "Administradores")]
        public ActionResult Create()
        {
            var dp = new DealerProcess();
            var listadealer = dp.SelectList();
            ViewData["Dealer"] = listadealer;

            return View();
        }


        [HttpPost]
        // POST: Products/Create
        //[Authorize(Roles = "Administradores")]
        public ActionResult Create(Product prd, HttpPostedFileBase Image)
        {

            if (Image != null)
            {
                string pic = System.IO.Path.GetFileName(Image.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"));

                //string path = "C:\\Users\\magnin\\Documents\\Maxi";
                //string path = "D:\\jpg";
                //Upload file
                Image.SaveAs(path+"\\"+pic);

                //Save Path on Database
                prd.Image = path + "\\" + pic;
            }
            

            var pp = new ProductProcess();
            pp.Insert(prd);
            return RedirectToAction("Index");
        }



        // GET: Products/Delete
        [Authorize(Roles = "Administradores")]
        public ActionResult Delete(int id)
        {
            var pp = new ProductProcess();
            pp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Products/Edit
        [Authorize(Roles = "Administradores")]
        public ActionResult Edit(int id)
        {
            var pp = new ProductProcess();
            var prd = pp.Find(id);

            var dp = new DealerProcess();
            var listadealer = dp.SelectList();
            ViewData["Dealer"] = listadealer;

            return View(prd);
        }

        [HttpPost]
        // POST: Products/Edit
        [Authorize(Roles = "Administradores")]
        public ActionResult Edit(Product prd)
        {
            var pp = new ProductProcess();
            pp.Edit(prd);
            return RedirectToAction("Index");
        }

        //// GET: Products/Product
        public ActionResult ProductList(int Category = -1)
        {

            var cp = new CategoryProcess();
            var pp = new ProductProcess();

            ViewData["Category"] = cp.SelectList();
            var lista = new List<Product>();

            if (Category > -1)
                lista = pp.SelectByCat(Category);

            return View(lista);
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"));

                //Upload file
                file.SaveAs(path);

                //Save Path on Database

            }
            return RedirectToAction("Index");
        }

    }
}