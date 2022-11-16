using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstDemo.Models;

namespace CodeFirstDemo.Controllers
{
    public class EnvoiceDetailsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: EnvoiceDetails
        public ActionResult Index()
        {
            var envoiceDetails = db.EnvoiceDetails.Include(e => e.Customer).Include(e => e.Invoice).Include(e => e.Seller);
            return View(envoiceDetails.ToList());
        }

        // GET: EnvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnvoiceDetail envoiceDetail = db.EnvoiceDetails.Find(id);
            if (envoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(envoiceDetail);
        }

        // GET: EnvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber");
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName");
            return View();
        }

        // POST: EnvoiceDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnvoiceDetailID,InvoiceID,CustomerID,SellerId")] EnvoiceDetail envoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.EnvoiceDetails.Add(envoiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", envoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", envoiceDetail.InvoiceID);
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", envoiceDetail.SellerId);
            return View(envoiceDetail);
        }

        // GET: EnvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnvoiceDetail envoiceDetail = db.EnvoiceDetails.Find(id);
            if (envoiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", envoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", envoiceDetail.InvoiceID);
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", envoiceDetail.SellerId);
            return View(envoiceDetail);
        }

        // POST: EnvoiceDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnvoiceDetailID,InvoiceID,CustomerID,SellerId")] EnvoiceDetail envoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envoiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", envoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", envoiceDetail.InvoiceID);
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", envoiceDetail.SellerId);
            return View(envoiceDetail);
        }

        // GET: EnvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnvoiceDetail envoiceDetail = db.EnvoiceDetails.Find(id);
            if (envoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(envoiceDetail);
        }

        // POST: EnvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnvoiceDetail envoiceDetail = db.EnvoiceDetails.Find(id);
            db.EnvoiceDetails.Remove(envoiceDetail);
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
