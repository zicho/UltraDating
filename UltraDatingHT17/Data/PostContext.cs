using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UltraDatingHT17.Entities;

namespace UltraDatingHT17.Data
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}