using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UltraDatingHT17.Models;
using System.Data.Entity;

namespace UltraDatingHT17.Controllers.Api
{
    public class PostsController : ApiController
    {
        public void AddPost(string content, string senderId, string recipientId)
        {
            
            using (var db = new ApplicationDbContext())
            {
                //var senderName = post.Sender;
                //var recipientId = post.Recipient;
                ApplicationUser sender = db.Users.Single(x => x.Id.Equals(senderId));
                ApplicationUser recipient = db.Users.Single(x => x.Id.Equals(recipientId));
                Post post = new Post { Content = content, Sender = sender, Recipient = recipient };
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public List<Post> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Posts.Include(x=>x.Sender).Include(x=>x.Recipient).ToList();
            }
        }
    }
}
