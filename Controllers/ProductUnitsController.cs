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
    public class ProductUnitsController : Controller
    {
        private DbContainer db = new DbContainer();

        // GET: ProductUnits
        public async Task<ActionResult> Index()
        {
            var productUnits = db.productUnits.Include(p => p.Product).Include(p => p.Unit);
            return View(await productUnits.ToListAsync());
        }

        // GET: ProductUnits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductUnit productUnit = await db.productUnits.FindAsync(id);
            if (productUnit == null)
            {
                return HttpNotFound();
            }
            return View(productUnit);
        }

        // GET: ProductUnits/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName");
            ViewBag.UnitId = new SelectList(db.units, "Id", "UnitName");
            return View();
        }

        // POST: ProductUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,UnitId")] ProductUnit productUnit)
        {
            if (ModelState.IsValid)
            {
                db.productUnits.Add(productUnit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productUnit.ProductId);
            ViewBag.UnitId = new SelectList(db.units, "Id", "UnitName", productUnit.UnitId);
            return View(productUnit);
        }

        // GET: ProductUnits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductUnit productUnit = await db.productUnits.FindAsync(id);
            if (productUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productUnit.ProductId);
            ViewBag.UnitId = new SelectList(db.units, "Id", "UnitName", productUnit.UnitId);
            return View(productUnit);
        }

        // POST: ProductUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,UnitId")] ProductUnit productUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productUnit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.products, "Id", "ProductName", productUnit.ProductId);
            ViewBag.UnitId = new SelectList(db.units, "Id", "UnitName", productUnit.UnitId);
            return View(productUnit);
        }

        // GET: ProductUnits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductUnit productUnit = await db.productUnits.FindAsync(id);
            if (productUnit == null)
            {
                return HttpNotFound();
            }
            return View(productUnit);
        }

        // POST: ProductUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductUnit productUnit = await db.productUnits.FindAsync(id);
            db.productUnits.Remove(productUnit);
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
