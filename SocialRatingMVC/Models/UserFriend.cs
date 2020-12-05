using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class UserFriend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public int FriendshipStatusId { get; set; }

        public IdentityUser User { get; set; }
        public IdentityUser Friend { get; set; }
        public FriendshipStatus FriendshipStatus { get; set; }
        
    }
}
