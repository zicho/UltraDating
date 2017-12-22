using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UltraDatingHT17.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Friends).WithMany()
                .Map(x=>x.ToTable("Friends"));
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.FriendRequests).WithMany()
                .Map(x => x.ToTable("FriendRequests"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }


}