using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;    
using Microsoft.AspNetCore.Mvc;
using SocialRatingMVC.Data;
using SocialRatingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Controllers
{
    
    public class FriendsController : Controller
    {
        private readonly SocialDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public FriendsController(SocialDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // GET: FriendsController
        
        public ActionResult Index()
        {
            var currentUser = this.User;
            var userId = _userManager.GetUserId(User);
            var userFriends = _context.UserFriends.Where(c => c.UserId == userId).ToList();
            var friendIds = userFriends.Select(c => c.FriendId);
            var friendList = _context.Users.Where(c => friendIds.ToList().Contains(c.Id)).ToList();
            ViewData["FriendList"] = friendList;
            return View();
        }

        [HttpGet]
        public ActionResult AddFriend([FromQuery] string userName = "")
        {
            var currentUser = this.User;
            var queryResult = new List<User>();
            if (userName != "")
            {
                queryResult = _context.Users.Where(c => c.UserName.Contains(userName)).ToList();
            }
            ViewData["SearchResult"] = queryResult;
            //var userFriends;
            return View();
        }

        [HttpPost]
        public ActionResult AddFriend([FromBody] AddFriendPostDto body)
        {
            try
            {
                var currentUserId = body.currentUserId;
                var friendUserName = body.userName;

                var friend = _context.Users.Where(c => c.UserName == friendUserName).Single();
                if (!_context.FriendshipStatuses.ToList().Any())
                {
                    var addnewStatus = new FriendshipStatus();

                    addnewStatus.Name = "Added";
                    _context.Add(addnewStatus);
                    _context.SaveChanges();
                }

                var userFriend = new UserFriend();
                userFriend.UserId = currentUserId;
                userFriend.FriendId = friend.Id;
                var addStatus = _context.FriendshipStatuses.Where(c => c.Name == "Added").Single();
                userFriend.FriendshipStatusId = addStatus.Id;
                _context.Add(userFriend);

                var revUserFriend = new UserFriend();
                revUserFriend.UserId = currentUserId;
                revUserFriend.FriendId = friend.Id;
                revUserFriend.FriendshipStatusId = addStatus.Id;
                _context.Add(userFriend);

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult SendReaction([FromBody] SendReactionDto body)
        {
            try
            {
                var reaction = new Reaction();
                reaction.FromUserId = body.currentUserId;

                var friend = _context.Users.Where(c => c.UserName == body.friendUsername).SingleOrDefault();
                reaction.ToUserId = friend.Id;
                reaction.ReactionText = body.reactionText;

                _context.Add(reaction);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: FriendsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FriendsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FriendsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FriendsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
