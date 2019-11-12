using ReferMe.Common.Helper;
using ReferMe.Model.common;
using ReferMe.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IPostService
    {
        int AddPost(PostDTO post);
        void DeletePost(int postId);
        List<PostDTO> PostsByUserId(int userId);
        PagedList<PostDTO> FilteredPostsByUserId(int userId, SearchParameter searchParameter);
        List<UserPostDTO> AllJobs(int loggedInUserId);
        PagedList<UserPostDTO> FilteredAllJobs(int loggedInUserId, SearchParameter searchParameter);
    }
}
