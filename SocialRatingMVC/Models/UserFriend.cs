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
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public int FriendshipStatusId { get; set; }

        public User User { get; set; }
        public User Friend { get; set; }
        public FriendshipStatus FriendshipStatus { get; set; }
        
    }
}
