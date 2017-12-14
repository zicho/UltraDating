using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UltraDatingHT17.Models
{
    public static class ClaimsExtension
    {
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.FirstOrDefault(c => c.Type == "Firstname");
            return firstName?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var lastName = principal.Claims.FirstOrDefault(c => c.Type == "Lastname");
            return lastName?.Value;
        }
    }
}