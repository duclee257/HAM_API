﻿using HAM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HAM_API.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            int userCount = db.tbl_user.ToList().Count;
            int doctorCount = db.tbl_doctor.ToList().Count;
            int DepCount = db.tbl_department.ToList().Count;
            int pending = db.tbl_booking.Where(x => x.status.Equals("Pending") || x.status.Equals("Chờ khám")).ToList().Count;
            ViewBag.doctorCount = doctorCount;
            ViewBag.userCount = userCount;
            ViewBag.DepCount = DepCount;
            ViewBag.pending = pending;
            ViewBag.news = db.tbl_news.ToList();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

     

    }

    
}