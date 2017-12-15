using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UltraDatingHT17.Models;

namespace UltraDatingHT17.Controllers
{
    public class HomeController : FieldController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View();
        }

        public new ActionResult Profile(string username)
        {
            try
            {
                if (username == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicationUser user = db.Users.FirstOrDefault(u => u.Profilename == username);

                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(user);
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }

        public ActionResult Friends()
        {


            return View();
        }

        public ActionResult Community()
        {
            return View(db.Users.ToList());
        }

        public ActionResult LogIn()
        {

            return View();
        }
    }
}