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
    [RoutePrefix("api/jobpost")]
    public class JobPostController : ApiController
    {
        ILogService loggerService;
        IPostService _postService;

        public JobPostController(ILogService loggerService, IPostService postService)
        {
            this.loggerService = loggerService;
            this._postService = postService;
        }

        [HttpPost]
        [Route("add")]
        public int Add(PostDTO post)
        {
            int postId = _postService.AddPost(post);
            return postId;
        }


        [HttpGet]
        [Route("all/{userId}")]
        public IEnumerable<PostDTO> PostsByUser(int userId)
        {
            return _postService.PostsByUserId(userId);
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<UserPostDTO> AllPosts()
        {
            return _postService.AllPosts();
        }

        [HttpDelete]
        [Route("delete")]
        public void DeletePost(int postId)
        {
            _postService.DeletePost(postId);
        }
    }
}
