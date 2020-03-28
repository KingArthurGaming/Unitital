﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitial.Services.Data;
using Unitial.Web.ViewModels;

namespace Unitial.Web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;

        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostInputModel createPostInput)
        {
            if (createPostInput.Caption.Length>65)
            {
                createPostInput.Caption = "";
            }
            var username = User.Identity.Name;
            var uesrId = postService.GetMyUserIdByUsername(username);

            postService.CreatePost(createPostInput, uesrId);

            return Redirect("/User/MyProfile");
        }

        [HttpPost]
        public IActionResult DeletePost(string id)
        {
            postService.DeletePost(id);
            return Redirect("/User/MyProfile");
        }

        


    }
}

