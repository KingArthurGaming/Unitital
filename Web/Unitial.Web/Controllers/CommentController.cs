﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitial.Services.Data;

namespace Unitial.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IProfileService profileService;
        private readonly IUserService userService;

        public CommentController(ICommentService commentService, IProfileService profileService, IUserService userService)
        {
            this.commentService = commentService;
            this.profileService = profileService;
            this.userService = userService;
        }
        public void CreateComment(string id, string comment)
        {
            if (comment.Length < 0 && comment.Length > 65)
            {
                return;
            }
            var username = User.Identity.Name;
            var uesrId = userService.GetUserIdByUsername(username);
            commentService.CreateComment(id, uesrId, comment);
        }
    }
}
