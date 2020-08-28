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
    public class ProductBrandsController : Controller
    {
        private DbContainer db = new DbContainer();

        // GET: ProductBrands
        public async Task<ActionResult> Index()
        {
            var productBrands = db.productBrands.Include(p => p.Brand).Include(p => p.Product);
            return View(await productBrands.ToListAsync());
        }

        // GET: ProductBrands/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = await db.productBrands.FindAsync(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // GET: ProductBrands/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.brands, "Id", "BrandName");
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName");
            return View();
        }

        // POST: ProductBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,BrandId")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                db.productBrands.Add(productBrand);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.brands, "Id", "BrandName", productBrand.BrandId);
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productBrand.ProductId);
            return View(productBrand);
        }

        // GET: ProductBrands/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = await db.productBrands.FindAsync(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.brands, "Id", "BrandName", productBrand.BrandId);
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productBrand.ProductId);
            return View(productBrand);
        }

        // POST: ProductBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,BrandId")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productBrand).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.brands, "Id", "BrandName", productBrand.BrandId);
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productBrand.ProductId);
            return View(productBrand);
        }

        // GET: ProductBrands/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = await db.productBrands.FindAsync(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // POST: ProductBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductBrand productBrand = await db.productBrands.FindAsync(id);
            db.productBrands.Remove(productBrand);
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
