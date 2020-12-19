
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserFriend> Friends { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }
    }
}
