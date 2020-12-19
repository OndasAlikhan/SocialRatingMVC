using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class AddFriendPostDto
    {
        public string userName { get; set; }
        public string currentUserId { get; set; }
    }
}
