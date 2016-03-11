using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API_Proj.Models;
using Microsoft.AspNet.Identity;

namespace API_Proj.Controllers
{
    public class RevenuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Revenues
        public ActionResult Index()
        {
            var revenues = db.Revenues.Include(r => r.Client).Include(r => r.RegisteredUser);
            var test = revenues.ToList();
            ViewBag.intArray = test;

            return View(revenues.ToList());
        }

        // GET: Revenues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // GET: Revenues/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Firstname");
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name");


            //ViewBag.RegisteredUserID = User.Identity.GetUserId();
            //ViewBag.RegisteredUserID = 1;
            return View();
        }

        // POST: Revenues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Total,Date,RegisteredUserID,RevenueCategoryID,ClientID")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                //var thing = revenue.RegisteredUserID;
                //var UserID = Convert.ToInt32(User.Identity.GetUserId().Single());
                //var foo = db.RegisteredUsers.Where(x => x.ID == UserID);
                //revenue.RegisteredUserID = ViewBag.RegisteredUserID;
                revenue.RegisteredUserID = User.Identity.GetUserId();
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Firstname", revenue.ClientID);
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name", revenue.RevenueCategoryID);
                
                db.Revenues.Add(revenue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);

            return View(revenue);
        }

        // GET: Revenues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Firstname", revenue.ClientID);
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);
            return View(revenue);
        }

        // POST: Revenues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Total,Date,RegisteredUserID,ClientID")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revenue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Firstname", revenue.ClientID);
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);
            return View(revenue);
        }

        // GET: Revenues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // POST: Revenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revenue revenue = db.Revenues.Find(id);
            db.Revenues.Remove(revenue);
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
