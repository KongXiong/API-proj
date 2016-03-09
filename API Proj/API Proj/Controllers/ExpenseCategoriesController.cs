﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API_Proj.Models;

namespace API_Proj.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExpenseCategories
        public ActionResult Index()
        {
            return View(db.ExpenseCategories.ToList());
        }

        // GET: ExpenseCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Total")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategories.Add(expenseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Total")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            db.ExpenseCategories.Remove(expenseCategory);
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