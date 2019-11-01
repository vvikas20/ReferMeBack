using ReferMe.API.Auth;
using ReferMe.API.Helper;
using ReferMe.API.Models;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/posts")]
    [JwtAuthentication]
    public class PostController : ApiController
    {
        ILogService loggerService;
        IPostService _postService;

        public PostController(ILogService loggerService, IPostService postService)
        {
            this.loggerService = loggerService;
            this._postService = postService;
        }

        [HttpPost]
        [Route("add")]
        public int Add(PostDTO post)
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            post.UserID = applicationUser.UserID;
            post.Contact = applicationUser.Mobile;
            int postId = _postService.AddPost(post);
            return postId;
        }

        [HttpGet]
        [Route("my")]
        public IEnumerable<PostDTO> PostsByMe()
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            return _postService.PostsByUserId(applicationUser.UserID);
        }

        [HttpGet]
        [Route("others")]
        public IEnumerable<UserPostDTO> PostedByOthers()
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            List<UserPostDTO> allPosts = _postService.AllPosts();

            return allPosts.Where(j => j.UserDetail.UserID != applicationUser.UserID).ToList();
        }

        [HttpDelete]
        [Route("delete")]
        public void DeletePost(int postId)
        {
            _postService.DeletePost(postId);
        }
    }
}
