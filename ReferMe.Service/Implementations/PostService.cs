﻿using ReferMe.DAL.Contracts;
using ReferMe.Model.common;
using ReferMe.Model.Common;
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
        IReferralRepository _referralRepository;
        IHelper _expressionBuilderService;

        public PostService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IReferralRepository referralRepository,
            IHelper expressionBuilderService)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
            this._referralRepository = referralRepository;
            this._expressionBuilderService = expressionBuilderService;
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
            objPost.PostedBy = post.UserID;
            objPost.PostedOn = DateTime.Now;
            _postRepository.Add(objPost);

            _unitOfWork.Commit();
            return objPost.PostID;

        }

        private int getNewPostId()
        {
            int postId = _postRepository.GetAll().Count() > 0 ? _postRepository.GetAll().Max(u => u.PostID) + 1 : 1;
            return postId;
        }

        public void DeletePost(int postId)
        {
            _referralRepository.Delete(r => r.PostID == postId);
            _postRepository.Delete(p => p.PostID == postId);
            _unitOfWork.Commit();
        }

        public List<PostDTO> PostsByUserId(int userId, SearchParameter searchParameter)
        {
            List<PostDTO> userPosts = new List<PostDTO>();
            var posts = _postRepository.GetMany(p => p.PostedBy == userId).ToList();

            IQueryable<Model.Entity.Post> queryResult = posts.AsQueryable();
            if (searchParameter.Filters != null && searchParameter.Filters.Count > 0)
            {
                List<Filter> clause = new List<Filter>();
                searchParameter.Filters.ForEach(f =>
                {
                    if (f.Field == "company")
                    {
                        clause.Add(new Filter
                        {
                            PropertyName = "Company",
                            Operation = Op.Contains,
                            Value = f.Value
                        });
                    }
                    if (f.Field == "location")
                    {
                        clause.Add(new Filter
                        {
                            PropertyName = "Location",
                            Operation = Op.Contains,
                            Value = f.Value
                        });
                    }
                    if (f.Field == "minExp")
                    {
                        clause.Add(new Filter
                        {
                            PropertyName = "MinExp",
                            Operation = Op.GreaterThanOrEqual,
                            Value = f.Value
                        });
                    }
                    if (f.Field == "maxExp")
                    {
                        clause.Add(new Filter
                        {
                            PropertyName = "MaxExp",
                            Operation = Op.LessThanOrEqual,
                            Value = f.Value
                        });
                    }
                });
                var deleg = _expressionBuilderService.GetExpression<Model.Entity.Post>(clause).Compile();
                queryResult = posts.Where(deleg).AsQueryable();
            }

            MyPagination pagination=new MyPagination(queryResult.Count(), searchParameter.Rows);
            posts = _expressionBuilderService.PagedIndex(queryResult, pagination,searchParameter.Page).ToList();

            foreach (Model.Entity.Post post in posts)
            {
                userPosts.Add(new PostDTO
                {
                    PostID = post.PostID,
                    Company = post.Company,
                    Position = post.Position,
                    MinExp = post.MinExp,
                    MaxExp = post.MaxExp,
                    Location = post.Location,
                    Contact = post.ContactNumber,
                    Description = post.Description,
                    PostedOn = post.PostedOn
                });
            }
            return userPosts;
        }

        public List<UserPostDTO> AllPosts()
        {
            List<UserPostDTO> userPosts = new List<UserPostDTO>();
            List<Model.Entity.Post> posts = _postRepository.GetAll().ToList();
            foreach (Model.Entity.Post post in posts)
            {
                userPosts.Add(
                    new UserPostDTO
                    {
                        PostDetail = new PostDTO
                        {
                            PostID = post.PostID,
                            Company = post.Company,
                            Position = post.Position,
                            MinExp = post.MinExp,
                            MaxExp = post.MaxExp,
                            Location = post.Location,
                            Contact = post.ContactNumber,
                            Description = post.Description,
                            PostedOn = post.PostedOn
                        },
                        UserDetail = new UserDTO
                        {
                            UserID = post.User.UserID,
                            EmailAddress = post.User.EmailAddress,
                            FirstName = post.User.FirstName,
                            MiddleName = post.User.MiddleName,
                            LastName = post.User.LastName,
                            Mobile = post.User.Mobile
                        }
                    }
                   );
            }
            return userPosts;
        }
    }
}
