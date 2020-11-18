using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SlijterijSjonnieLoper;

namespace SlijterijSjonnieLoper.Core
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string FavoriteDrink { get; set; }

    }
}
