using ReferMe.Model.Entity;
using System;

namespace ReferMe.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        ReferMeEntities Get();
    }
}
