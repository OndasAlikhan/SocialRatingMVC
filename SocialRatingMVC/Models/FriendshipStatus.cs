using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class FriendshipStatus
    {
        public readonly static string NAME_ADDED = "Added";

        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
