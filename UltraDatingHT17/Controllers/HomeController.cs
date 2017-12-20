using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        private static Random rnd = new Random();

        public ActionResult Index()
        {
            //var greger = db.Users.Single(x => x.Firstname == "Jävlar");
            //greger.Friends.Add(db.Users.Single(x => x.Firstname == "Raskal"));
            //db.SaveChanges();
            //var gregersvänner = greger.Friends.ToList();
            //var friendTestString = "Gregers vänner: ";
            //foreach(var friend in gregersvänner)
            //{
            //    friendTestString += friend.Firstname;
            //}
            //ViewBag.Friends = friendTestString;
            var users = db.Users.ToList();

            ViewBag.RandomUsers = users.OrderBy(x => rnd.Next()).Take(1);

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
                //Test för första post
                //PostContext pb = new PostContext();
                //pb.Posts.Add(new Entities.Post
                //{
                //    Content = "Test test hej hå",
                //    Author = user,
                //    ShoutboxOwner = user
                //});

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

        public ActionResult EditProfile(string username)
        {
            try
            {
                if (username == null)
                {
                    RedirectToAction("Index", "Home");
                }

                var user = db.Users.FirstOrDefault(u => u.Profilename == username);

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

        [HttpPost]
        public ActionResult EditProfile(ApplicationUser editedUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Profilename == editedUser.Profilename);
                    
                    if (editedUser.Firstname.Any(char.IsDigit))
                    {
                        Response.Write("Names can't contain numbers!");

                        return View();
                    }
                    if (editedUser.Lastname.Any(char.IsDigit))
                    {
                        Response.Write("Names can't contain numbers!");

                        return View();
                    }

                    user.Firstname = editedUser.Firstname;
                    user.Lastname = editedUser.Lastname;
                    user.ProfileInfo = editedUser.ProfileInfo;
                    user.IsSearchable = editedUser.IsSearchable;

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile", "Home", new { username = user.Profilename});

                }
                catch
                {
                    RedirectToAction("Index", "Home");
                }
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

        public ActionResult Search(string name = "")
        {
            List<ApplicationUser> matchedUsers = new List<ApplicationUser>();
            matchedUsers.AddRange(db.Users.ToList().Where(i => (i.Firstname.ToLower() + ' ' + i.Lastname.ToLower()).Contains(name.ToLower())));

            if (matchedUsers != null)
            {
                return View(matchedUsers);
            }
            else
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult LogIn()
        {

            return View();
        }
    }
}