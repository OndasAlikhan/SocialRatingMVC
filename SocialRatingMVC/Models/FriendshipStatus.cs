using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class FriendshipStatus
    {
        private readonly static int STATUS_REQUESTED = 0;
        private readonly static int STATUS_ADDED = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
