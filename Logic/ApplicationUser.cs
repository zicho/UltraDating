using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UltraDatingHT17.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "You need to enter a first name.")]
        [RegularExpression("^[A-Öa-ö]*$", ErrorMessage = @"No whitespace or numbers in first name.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name *")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "You need to enter a last name.")]
        [RegularExpression("^[A-Öa-ö]*$", ErrorMessage = @"No whitespace or numbers in last name.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name *")]
        public string Lastname { get; set; }

        public string Profilename { get; set; }

        [Display(Name = "Include your profile in search?")]
        public bool IsSearchable { get; set; }

        [StringLength(420, ErrorMessage = "Your profile must be between 3 and 420 characters long.", MinimumLength = 3)]
        [Display(Name = "Profile Info")]
        public string ProfileInfo { get; set; }

        [Display(Name = "Profile Pic")]
        public byte[] ProfilePicture { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }

        public virtual ICollection<ApplicationUser> Friends { get; set; }
        public virtual ICollection<ApplicationUser> FriendRequests { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public ApplicationUser()
        {

            // lägger till standardfält på våra användare

            IsSearchable = true;

            this.Friends = new HashSet<ApplicationUser>();
            this.FriendRequests = new HashSet<ApplicationUser>();
        }
    }


}