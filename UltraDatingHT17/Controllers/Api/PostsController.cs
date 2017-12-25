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
        [HttpPost]
        public void AddPost(ApiPost apiPost)
        {
            
            using (var db = new ApplicationDbContext())
            {
                //var senderName = post.Sender;
                //var recipientId = post.Recipient;
                ApplicationUser sender = db.Users.SingleOrDefault(x => x.Id.Equals(apiPost.SenderId));
                ApplicationUser recipient = db.Users.SingleOrDefault(x => x.Id.Equals(apiPost.RecieverId));
                Post post = new Post { Content = apiPost.PostContent, Sender = sender, Recipient = recipient };
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

    public class ApiPost
    {
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string PostContent { get; set; }
    }
}
