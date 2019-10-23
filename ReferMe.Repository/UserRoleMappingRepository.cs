﻿using ReferMe.DAL.Contracts;
using ReferMe.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Repository
{
    public class UserRoleMappingRepository : Repository<Model.Entity.UserRoleMapping>, IUserRoleMappingRepository
    {
        private Model.Entity.ReferMeEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public UserRoleMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected Model.Entity.ReferMeEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IUserRoleMappingRepository : IRepository<Model.Entity.UserRoleMapping>
    {
    }
}
