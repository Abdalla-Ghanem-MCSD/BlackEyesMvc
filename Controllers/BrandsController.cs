using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlackEyesMvc.Models;
using System.IO;

namespace BlackEyesMvc.Controllers
{
    public class BrandsController : Controller
    {
        private DbContainer db = new DbContainer();

        // GET: Brands
        public ActionResult Index()
        {
            return View(db.brands.ToList());
        }

        // GET: Brands/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = await db.brands.FindAsync(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string brandName, HttpPostedFileBase file)
        {
            Brand brand = new Brand();
            if (brandName != null)
            {
                if (file != null)
                {
                    string ImagePath = "~/IMG/" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath(ImagePath));

                    brand.BrandName = brandName;
                    string Actualpath = ImagePath.Substring(1);
                    brand.PhotoUrl = Actualpath;
                }
                db.brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(int id, string brandName, HttpPostedFileBase file)
        {
            Brand brand = db.brands.Find(id);
            if (brand != null)
            {
                if (brandName != null)
                {
                    if (file != null)
                    {
                        string ImagePath = "~/IMG/" + file.FileName;
                        file.SaveAs(HttpContext.Server.MapPath(ImagePath));

                        brand.BrandName = brandName;
                        string Actualpath = ImagePath.Substring(1);
                        brand.PhotoUrl = Actualpath;
                    }
                    db.Entry(brand).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            return View();
        }


        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = await db.brands.FindAsync(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            Brand brand = db.brands.Find(id);
            db.brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
