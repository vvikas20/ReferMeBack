using ReferMe.API.Auth;
using ReferMe.API.Helper;
using ReferMe.API.Models;
using ReferMe.Common.Contracts;
using ReferMe.Common.Helper;
using ReferMe.Model.common;
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
    [RoutePrefix("api/jobposts")]
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

        [HttpPost]
        [Route("my-posts")]
        public PagedList<PostDTO> MyPosts(SearchParameter searchParameter)
        {
            if (searchParameter == null) searchParameter = new SearchParameter();

            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            return _postService.FilteredPostsByUserId(applicationUser.UserID, searchParameter);
        }

        [HttpPost]
        [Route("jobs")]
        public PagedList<JobDTO> Jobs(SearchParameter searchParameter)
        {
            if (searchParameter == null) searchParameter = new SearchParameter();

            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            return _postService.FilteredAllJobs(applicationUser.UserID, searchParameter);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeletePost(int postId)
        {
            _postService.DeletePost(postId);
        }
    }
}
