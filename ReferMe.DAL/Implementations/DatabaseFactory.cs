using ReferMe.DAL.Contracts;
using ReferMe.Model.Entity;

namespace ReferMe.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ReferMeEntities dataContext;
        public ReferMeEntities Get()
        {
            return dataContext ?? (dataContext = new ReferMeEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
