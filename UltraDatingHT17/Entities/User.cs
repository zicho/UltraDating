using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltraDatingHT17.Entities
{
    public class User
    {
        public int userID { get; set; } //Eller GUID eller vad fan det är
        public virtual List<Post> ShoutboxPosts { get; set; }
    }
}