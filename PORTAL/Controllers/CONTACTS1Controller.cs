using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PORTAL.Models;

namespace PORTAL.Controllers
{
    public class CONTACTS1Controller : Controller
    {
        private PIPESEntities db = new PIPESEntities();

        // GET: CONTACTS1
        public ActionResult Index()
        {
            var cONTACTS = db.CONTACTS.Include(c => c.LOOKUP);
            return View(cONTACTS.ToList());
        }

        // GET: CONTACTS1/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTS cONTACTS = db.CONTACTS.Find(id);
            if (cONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTS);
        }

        // GET: CONTACTS1/Create
        public ActionResult Create()
        {
            ViewBag.CONTACTTYPEID = new SelectList(db.LOOKUP, "LOOKUPID", "FIELDTYPE");
            return View();
        }

        // POST: CONTACTS1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CONTACTID,CONTACTTYPEID,INTERNALUSERNAME,CONTACTNAME,CONTACTPHONE,EXTENSION,EMAIL,COMPANYID,IS_ACTIVE,ADDED_BY,ADDED_DT,UPDATED_BY,UPDATED_DT")] CONTACTS cONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTS.Add(cONTACTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CONTACTTYPEID = new SelectList(db.LOOKUP, "LOOKUPID", "FIELDTYPE", cONTACTS.CONTACTTYPEID);
            return View(cONTACTS);
        }

        // GET: CONTACTS1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTS cONTACTS = db.CONTACTS.Find(id);
            if (cONTACTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONTACTTYPEID = new SelectList(db.LOOKUP, "LOOKUPID", "FIELDTYPE", cONTACTS.CONTACTTYPEID);
            return View(cONTACTS);
        }

        // POST: CONTACTS1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CONTACTID,CONTACTTYPEID,INTERNALUSERNAME,CONTACTNAME,CONTACTPHONE,EXTENSION,EMAIL,COMPANYID,IS_ACTIVE,ADDED_BY,ADDED_DT,UPDATED_BY,UPDATED_DT")] CONTACTS cONTACTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTACTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CONTACTTYPEID = new SelectList(db.LOOKUP, "LOOKUPID", "FIELDTYPE", cONTACTS.CONTACTTYPEID);
            return View(cONTACTS);
        }

        // GET: CONTACTS1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTS cONTACTS = db.CONTACTS.Find(id);
            if (cONTACTS == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTS);
        }

        // POST: CONTACTS1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTACTS cONTACTS = db.CONTACTS.Find(id);
            db.CONTACTS.Remove(cONTACTS);
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
