﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HAM_API.Models;

namespace HAM_API.Controllers
{
    public class DoctorController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Doctor
        public ActionResult Index()
        {
            var tbl_doctor = db.tbl_doctor.Include(t => t.tbl_department).Include(t => t.tbl_user);
            return View(tbl_doctor.ToList());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_doctor tbl_doctor = db.tbl_doctor.Find(id);
            if (tbl_doctor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            ViewBag.dep_id = new SelectList(db.tbl_department, "id", "name");
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "email");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,room,dep_id,user_id")] tbl_doctor tbl_doctor)
        {
            if (ModelState.IsValid)
            {
                db.tbl_doctor.Add(tbl_doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dep_id = new SelectList(db.tbl_department, "id", "name", tbl_doctor.dep_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "email", tbl_doctor.user_id);
            return View(tbl_doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_doctor tbl_doctor = db.tbl_doctor.Find(id);
            if (tbl_doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.dep_id = new SelectList(db.tbl_department, "id", "name", tbl_doctor.dep_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "email", tbl_doctor.user_id);
            return View(tbl_doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,room,dep_id,user_id")] tbl_doctor tbl_doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dep_id = new SelectList(db.tbl_department, "id", "name", tbl_doctor.dep_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "email", tbl_doctor.user_id);
            return View(tbl_doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_doctor tbl_doctor = db.tbl_doctor.Find(id);
            if (tbl_doctor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_doctor tbl_doctor = db.tbl_doctor.Find(id);
            db.tbl_doctor.Remove(tbl_doctor);
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