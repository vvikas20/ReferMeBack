using ReferMe.DAL.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Repository;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Implementations
{
    public class PostService : IPostService
    {
        IUnitOfWork _unitOfWork;
        IPostRepository _postRepository;
        IUserPostRepository _userPostRepository;

        public PostService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IUserPostRepository userPostRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
            this._userPostRepository = userPostRepository;
        }

        public int AddPost(PostDTO post)
        {
            Model.Entity.Post objPost = new Model.Entity.Post();
            objPost.PostID = getNewPostId();
            objPost.Company = post.Company;
            objPost.Position = post.Position;
            objPost.MinExp = post.MinExp;
            objPost.MaxExp = post.MaxExp;
            objPost.Location = post.Location;
            objPost.ContactNumber = post.Contact;
            objPost.Description = post.Description;
            _postRepository.Add(objPost);
            _unitOfWork.Commit();

            Model.Entity.UserPostMapping objUserPostMapping = new Model.Entity.UserPostMapping();
            objUserPostMapping.MappingID = getNewUserPostMappingId();
            objUserPostMapping.PostID = objPost.PostID;
            objUserPostMapping.UserID = post.UserID;
            _userPostRepository.Add(objUserPostMapping);
            _unitOfWork.Commit();

            return objPost.PostID;

        }

        private int getNewPostId()
        {
            int postId = _postRepository.GetAll().Count() > 0 ? _postRepository.GetAll().Max(u => u.PostID) + 1 : 1;
            return postId;
        }

        private int getNewUserPostMappingId()
        {
            int mappingId = _userPostRepository.GetAll().Count() > 0 ? _userPostRepository.GetAll().Max(u => u.MappingID) + 1 : 1;
            return mappingId;
        }

        public void DeletePost(int postId)
        {
            _userPostRepository.Delete(u => u.PostID == postId);
            _unitOfWork.Commit();

            _postRepository.Delete(p => p.PostID == postId);
            _unitOfWork.Commit();
        }

        public List<PostDTO> PostsByUserId(int userId)
        {
            List<PostDTO> userPosts = new List<PostDTO>();
            List<Model.Entity.UserPostMapping> mappings = _userPostRepository.GetMany(p => p.UserID == userId).ToList();
            foreach (Model.Entity.UserPostMapping mapping in mappings)
            {
                userPosts.Add(new PostDTO
                {
                    PostID = mapping.Post.PostID,
                    Company = mapping.Post.Company,
                    Position = mapping.Post.Position,
                    MinExp = mapping.Post.MinExp,
                    MaxExp = mapping.Post.MaxExp,
                    Location = mapping.Post.Location,
                    Contact = mapping.Post.ContactNumber,
                    Description = mapping.Post.Description
                });
            }
            return userPosts;
        }

        public List<UserPostDTO> AllPosts()
        {
            List<UserPostDTO> userPosts = new List<UserPostDTO>();
            List<Model.Entity.UserPostMapping> mappings = _userPostRepository.GetAll().ToList();
            foreach (Model.Entity.UserPostMapping mapping in mappings)
            {
                userPosts.Add(
                    new UserPostDTO
                    {
                        PostDetail = new PostDTO
                        {
                            PostID = mapping.Post.PostID,
                            Company = mapping.Post.Company,
                            Position = mapping.Post.Position,
                            MinExp = mapping.Post.MinExp,
                            MaxExp = mapping.Post.MaxExp,
                            Location = mapping.Post.Location,
                            Contact = mapping.Post.ContactNumber,
                            Description = mapping.Post.Description
                        },
                        UserDetail = new UserDTO
                        {
                            EmailAddress = mapping.User.EmailAddress,
                            FirstName = mapping.User.FirstName,
                            MiddleName = mapping.User.MiddleName,
                            LastName = mapping.User.LastName,
                            Mobile = mapping.User.Mobile
                        }
                    }
                   );
            }
            return userPosts;
        }
    }
}
