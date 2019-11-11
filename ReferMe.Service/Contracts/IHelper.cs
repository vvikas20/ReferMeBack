using ReferMe.Model.common;
using ReferMe.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IHelper
    {
        Expression<Func<T, bool>> GetExpression<T>(IList<Filter> filters);
        IQueryable<t> PagedIndex<t>(IQueryable<t> query, MyPagination pagination, int pageIndex);
    }
}
