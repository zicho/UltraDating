using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltraDatingHT17.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public User ShoutboxOwner { get; set; }
    }
}