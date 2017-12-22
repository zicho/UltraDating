using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltraDatingHT17.Models;

namespace UltraDatingHT17.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcceptFriendRequest(string friendId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var currentUserId = User.Identity.GetUserId();
                    var currentUser = db.Users.SingleOrDefault(x => x.Id == currentUserId);
                    var newFriend = db.Users.SingleOrDefault(x => x.Id == friendId);
                    currentUser.Friends.Add(newFriend);
                    newFriend.Friends.Add(currentUser);

                    currentUser.FriendRequests.Remove(newFriend);

                    db.SaveChanges();
                    return RedirectToAction("Friends", "Home", new { id = currentUserId });
                }
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Hey ho");
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public ActionResult RemoveFriend(string friendID)
        {
            try
            {
                using(var db = new ApplicationDbContext())
                {
                    var currentUserId = User.Identity.GetUserId();
                    var currentUser = db.Users.SingleOrDefault(x => x.Id == currentUserId);
                    var removedFriend = db.Users.SingleOrDefault(x => x.Id == friendID);

                    currentUser.Friends.Remove(removedFriend);
                    removedFriend.Friends.Remove(currentUser);

                    db.SaveChanges();
                    return RedirectToAction("Friends", "Home", new { id = currentUserId });
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Hey ho");
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public ActionResult DeclineFriendRequest(string friendId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var currentUserId = User.Identity.GetUserId();
                    var currentUser = db.Users.SingleOrDefault(x => x.Id == currentUserId);

                    var failedFriend = db.Users.SingleOrDefault(x => x.Id == friendId);
                    currentUser.FriendRequests.Remove(failedFriend);
                    db.SaveChanges();

                    return RedirectToAction("Friends", "Home", new { id = currentUserId });
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Hey ho");
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public ActionResult AddFriendRequest(string friendId)
        {
            using (var db = new ApplicationDbContext())
            {
                var newFriend = db.Users.SingleOrDefault(x => x.Id == friendId);

                var currentUserId = User.Identity.GetUserId();
                var currentUser = db.Users.SingleOrDefault(x => x.Id == currentUserId);

                newFriend.FriendRequests.Add(currentUser);

                db.SaveChanges();
                    
                return RedirectToAction("Friends", "Home", new { id = currentUserId });
            }
        }
    }
}