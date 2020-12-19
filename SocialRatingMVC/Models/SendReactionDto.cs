using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Models
{
    public class SendReactionDto
    {
        public string currentUserId { get; set; }
        public string friendUsername { get; set; }
        public string reactionText { get; set; }
    }
}
