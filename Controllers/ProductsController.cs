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

namespace BlackEyesMvc.Controllers
{
    public class ProductsController : Controller
    {
        private DbContainer db = new DbContainer();

        
        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = db.products.Include(p => p.Category);
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName");
            //ViewBag.OrderId = new SelectList(db.orders, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String ProductName , HttpPostedFileBase file)
        {
            Product product = new Product();
            if (ProductName != null)
            {
                if (file != null)
                {
                    string ImagePath = "~/ProductIMG/" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath(ImagePath));

                    product.ProductName = ProductName;
                    string Actualpath = ImagePath.Substring(1);
                    product.Photo = Actualpath;
                }
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id, string ProductName, string Description, int price, int CategoryId,  HttpPostedFileBase file)
        {
            Product product =  db.products.Find(id);
            if (product != null)
            {
                if (ProductName != null)
                {
                    if (file != null)
                    {
                        string ImagePath = "~/IMG/" + file.FileName;
                        file.SaveAs(HttpContext.Server.MapPath(ImagePath));

                        product.ProductName = ProductName;
                        string Actualpath = ImagePath.Substring(1);
                        product.Photo = Actualpath;
                    }
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductName,Description,Photo,price,CategoryId,OrderId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", product.CategoryId);
            
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.products.FindAsync(id);
            db.products.Remove(product);
            await db.SaveChangesAsync();
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
