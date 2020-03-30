using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitial.Services.Data;

namespace Unitial.Web.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {
        private readonly IFollowService followService;

        public FollowController(IFollowService followService)
        {
            this.followService = followService;
        }
        public string FollowUser(string FollowedId)
        {
            var username = User.Identity.Name;
            var uesrId = followService.GetMyUserIdByUsername(username);
            var isFollowed = followService.IsFollowed(uesrId, FollowedId);
            if (isFollowed == "Followed")
            {
                followService.Unfollow(uesrId, FollowedId);
            }
            else
            {
                followService.Follow(uesrId, FollowedId);
            }
            return isFollowed;

        }
    }
}