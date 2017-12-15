using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltraDatingHT17.Models;

namespace UltraDatingHT17.Controllers
{
    public class FieldController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);

                    if(user != null) { 
                    string fullName = string.Concat(new string[] { user.Firstname, " ", user.Lastname });
                    string firstName = user.Firstname;
                    string lastName = user.Lastname;

                    ViewData.Add("FullName", fullName);
                    ViewData.Add("FirstName", firstName);
                    ViewData.Add("LastName", lastName);
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }

    }
}