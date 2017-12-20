using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

        public new ActionResult Profile(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == id);
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

        [HttpPost]
        public ActionResult UploadPicture(string id, HttpPostedFileBase image)
        {
            try
            {
                if (id == null)
                {
                    RedirectToAction("Index", "Home");
                }

                var user = db.Users.FirstOrDefault(u => u.Id == id);

                if(image != null && image.ContentLength > 0){
                    user.Filename = image.FileName;
                    user.ContentType = image.ContentType;

                    using (var reader = new BinaryReader(image.InputStream))
                    {
                        user.ProfilePicture = reader.ReadBytes(image.ContentLength);
                    }

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                }

                if (user == null)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Profile", "Home", new { id = user.Id });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult GetImage(string id)
        {
            var image = db.Users.Single(x => x.Id == id);
            return File(image.ProfilePicture, image.ContentType);
        }

        public ActionResult EditProfile(string id)
        {
            try
            {
                if (id == null)
                {
                    RedirectToAction("Index", "Home");
                }

                var user = db.Users.FirstOrDefault(u => u.Id == id);

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
                    var user = db.Users.FirstOrDefault(u => u.Id == editedUser.Id);
                   
                    user.Firstname = editedUser.Firstname;
                    user.Lastname = editedUser.Lastname;
                    user.ProfileInfo = editedUser.ProfileInfo;
                    user.IsSearchable = editedUser.IsSearchable;

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile", "Home", new { id = user.Id});

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

        public ActionResult Friends(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == id);


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

        public ActionResult Community()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Search(string name = "")
        {
            List<ApplicationUser> matchedUsers = new List<ApplicationUser>();
            matchedUsers.AddRange(db.Users.ToList().Where(i => (i.Firstname.ToLower() + ' ' + i.Lastname.ToLower()).Contains(name.ToLower()) && i.IsSearchable == true));

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
        public ActionResult AddFriend(string friendId)
        {
            try
            {
                var currentUserId = User.Identity.GetUserId();
                var currentUser = db.Users.SingleOrDefault(x => x.Id == currentUserId);
                var newFriend = db.Users.SingleOrDefault(x => x.Id == friendId);
                currentUser.Friends.Add(newFriend);
                newFriend.Friends.Add(currentUser);
                db.SaveChanges();
                return RedirectToAction("Friends", "Home", new { id = currentUserId });
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}