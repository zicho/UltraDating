using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltraDatingHT17.Models;
using System.Data.Entity;

namespace UltraDatingHT17.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index(string profileId)
        {
            using (var db = new ApplicationDbContext())
            {
                var posts = db.Posts.Include(x => x.Sender).Where(i => i.Recipient.Id == profileId).ToList();
                return View(new PostIndexViewModel { Id = profileId, Posts = posts });
            }
                
        }
        public ActionResult Delete(string Id)
        {
            using (var db = new ApplicationDbContext())
            {
                var post = db.Posts.Single(x => x.Id.ToString().Equals(Id));
                var profileId = post.Recipient.Id;
                db.Posts.Remove(post);
                db.SaveChanges();
                return RedirectToAction("Profile/" + profileId,"Home");
            }
        }
    }
    public class PostIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Post> Posts { get; set; }
        public PostIndexViewModel()
            {

            }
        public PostIndexViewModel(string Id)
        {
            using (var db = new ApplicationDbContext())
            {
                this.Posts = db.Posts.Include(x => x.Sender).Where(i => i.Recipient.Id == Id).ToList();
                try
                {

                }
                catch
                {

                }
                this.Id = Id;
            }

        }
    }
}