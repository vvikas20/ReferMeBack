using ReferMe.Common.Helper;
using ReferMe.DAL.Contracts;
using ReferMe.Model.common;
using ReferMe.Model.DTO;
using ReferMe.Repository;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReferMe.Service.Implementations
{
    public class PostService : IPostService
    {
        IUnitOfWork _unitOfWork;
        IPostRepository _postRepository;
        IReferralRepository _referralRepository;

        public PostService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IReferralRepository referralRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
            this._referralRepository = referralRepository;
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
            objPost.Keywords = string.Join("##", post.Keywords.ToArray());
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

        public List<PostDTO> PostsByUserId(int userId)
        {
            List<PostDTO> posts = new List<PostDTO>();
            var postEntities = _postRepository.GetMany(p => p.PostedBy == userId).ToList();
            foreach (Model.Entity.Post post in postEntities)
            {
                posts.Add(new PostDTO
                {
                    PostID = post.PostID,
                    Company = post.Company,
                    Position = post.Position,
                    MinExp = post.MinExp,
                    MaxExp = post.MaxExp,
                    Location = post.Location,
                    Contact = post.ContactNumber,
                    Description = post.Description,
                    Keywords = string.IsNullOrWhiteSpace(post.Keywords) ? new List<string>() : post.Keywords.Split(new[] { "##" }, StringSplitOptions.None).ToList(),
                    PostedOn = post.PostedOn
                });
            }
            return posts;
        }

        public PagedList<PostDTO> FilteredPostsByUserId(int userId, SearchParameter searchParameter)
        {
            List<PostDTO> posts = new List<PostDTO>();

            var predicate = PredicateBuilder.True<Model.Entity.Post>();
            predicate = predicate.And(i => i.PostedBy == userId);
            if (searchParameter.Filters != null && searchParameter.Filters.Count > 0)
            {
                searchParameter.Filters.ForEach(f =>
                {
                    if (f.Field == "keywords")
                    {
                        var subPredicate = PredicateBuilder.False<Model.Entity.Post>();
                        List<string> keys = f.Value.Split(new[] { "##" }, StringSplitOptions.None).ToList();
                        keys.ForEach(key =>
                        {
                            subPredicate = subPredicate.Or(i => i.Keywords.ToLower().Contains(key.ToLower()));
                        });

                        predicate = predicate.And(subPredicate);
                    }
                    if (f.Field == "company")
                    {
                        predicate = predicate.And(i => i.Company.ToLower().Contains(f.Value.ToLower()));
                    }
                    if (f.Field == "location")
                    {
                        predicate = predicate.And(i => i.Location.ToLower().Contains(f.Value.ToLower()));
                    }
                    if (f.Field == "minExp")
                    {
                        int min = int.Parse(f.Value);
                        predicate = predicate.And(i => i.MinExp >= min);
                    }
                    if (f.Field == "maxExp")
                    {
                        int max = int.Parse(f.Value);
                        predicate = predicate.And(i => i.MaxExp <= max);
                    }
                });
            }

            IQueryable<Model.Entity.Post> queryResult = _postRepository.GetMany(predicate).AsQueryable();

            Pagination pagination = new Pagination(queryResult.Count(), searchParameter.Rows);
            queryResult = queryResult.PagedIndex(pagination, searchParameter.Page);

            foreach (Model.Entity.Post post in queryResult)
            {
                posts.Add(new PostDTO
                {
                    PostID = post.PostID,
                    Company = post.Company,
                    Position = post.Position,
                    MinExp = post.MinExp,
                    MaxExp = post.MaxExp,
                    Location = post.Location,
                    Contact = post.ContactNumber,
                    Description = post.Description,
                    Keywords = string.IsNullOrWhiteSpace(post.Keywords) ? new List<string>() : post.Keywords.Split(new[] { "##" }, StringSplitOptions.None).ToList(),
                    PostedOn = post.PostedOn
                });
            }

            return new PagedList<PostDTO>(posts.AsQueryable(), searchParameter.Page, pagination.PageSize, pagination.MaxPage, pagination.TotalItems);
        }

        public List<UserPostDTO> AllJobs(int loggedInUserId)
        {
            List<UserPostDTO> jobs = new List<UserPostDTO>();
            List<Model.Entity.Post> jobEntities = _postRepository.GetAll().Where(p => p.PostedBy != loggedInUserId).ToList();
            foreach (Model.Entity.Post post in jobEntities)
            {
                jobs.Add(
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
                            Keywords = string.IsNullOrWhiteSpace(post.Keywords) ? new List<string>() : post.Keywords.Split(new[] { "##" }, StringSplitOptions.None).ToList(),
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

            return jobs;
        }

        public PagedList<UserPostDTO> FilteredAllJobs(int loggedInUserId, SearchParameter searchParameter)
        {
            List<UserPostDTO> jobs = new List<UserPostDTO>();

            var predicate = PredicateBuilder.True<Model.Entity.Post>();
            predicate = predicate.And(i => i.PostedBy != loggedInUserId);
            if (searchParameter.Filters != null && searchParameter.Filters.Count > 0)
            {
                searchParameter.Filters.ForEach(f =>
                {
                    if (f.Field == "keywords")
                    {
                        var subPredicate = PredicateBuilder.False<Model.Entity.Post>();
                        List<string> keys = f.Value.Split(new[] { "##" }, StringSplitOptions.None).ToList();
                        keys.ForEach(key =>
                        {
                            subPredicate = subPredicate.Or(i => i.Keywords.ToLower().Contains(key.ToLower()));
                        });

                        predicate = predicate.And(subPredicate);
                    }
                    if (f.Field == "company")
                    {
                        predicate = predicate.And(i => i.Company.ToLower().Contains(f.Value.ToLower()));
                    }
                    if (f.Field == "location")
                    {
                        predicate = predicate.And(i => i.Location.ToLower().Contains(f.Value.ToLower()));
                    }
                    if (f.Field == "minExp")
                    {
                        int min = int.Parse(f.Value);
                        predicate = predicate.And(i => i.MinExp >= min);
                    }
                    if (f.Field == "maxExp")
                    {
                        int max = int.Parse(f.Value);
                        predicate = predicate.And(i => i.MaxExp <= max);
                    }
                });
            }

            IQueryable<Model.Entity.Post> queryResult = _postRepository.GetMany(predicate).AsQueryable();

            Pagination pagination = new Pagination(queryResult.Count(), searchParameter.Rows);
            queryResult = queryResult.PagedIndex(pagination, searchParameter.Page);

            foreach (Model.Entity.Post post in queryResult)
            {
                jobs.Add(
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
                            Keywords = string.IsNullOrWhiteSpace(post.Keywords) ? new List<string>() : post.Keywords.Split(new[] { "##" }, StringSplitOptions.None).ToList(),
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

            return new PagedList<UserPostDTO>(jobs.AsQueryable(), searchParameter.Page, pagination.PageSize, pagination.MaxPage, pagination.TotalItems);
        }
    }
}
