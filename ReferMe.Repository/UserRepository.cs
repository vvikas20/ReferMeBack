using ReferMe.DAL.Contracts;
using ReferMe.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Repository
{
    public class UserRepository : Repository<Model.Entity.User>, IUserRepository
    {
        private Model.Entity.ReferMeEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected Model.Entity.ReferMeEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }


    }
    public interface IUserRepository : IRepository<Model.Entity.User>
    {
    }
}
