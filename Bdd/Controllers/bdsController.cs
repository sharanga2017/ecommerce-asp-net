using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bdd.Models;

namespace Bdd.Controllers
{
    public class bdsController : Controller
    {
        private MyBdd db = new MyBdd();

        // GET: bds
        public async Task<ActionResult> Index()
        {
            ViewBag.JPG = ".jpg";
            return View(await db.bds.ToListAsync());
        }

        // GET: bds/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bd bd = await db.bds.FindAsync(id);
            if (bd == null)
            {
                return HttpNotFound();
            }
            return View(bd);
        }

        // GET: bds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "_ref,image,heros,titre,prixPublic,resume,idSerie,idGenre")] bd bd)
        {
            if (ModelState.IsValid)
            {
                db.bds.Add(bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bd);
        }

        // GET: bds/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bd bd = await db.bds.FindAsync(id);
            if (bd == null)
            {
                return HttpNotFound();
            }
            return View(bd);
        }

        // POST: bds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "_ref,image,heros,titre,prixPublic,resume,idSerie,idGenre")] bd bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bd);
        }

        // GET: bds/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bd bd = await db.bds.FindAsync(id);
            if (bd == null)
            {
                return HttpNotFound();
            }
            return View(bd);
        }

        // POST: bds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            bd bd = await db.bds.FindAsync(id);
            db.bds.Remove(bd);
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
