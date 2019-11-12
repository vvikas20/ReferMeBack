using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Common.Helper
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> list, int page, int pageSize, int totallPage, int totallItem)
        {
            _list = list;
            this.Page = page;
            this.PageSize = pageSize;
            this.TotallPage = totallPage;
            this.TotallItem = totallItem;
        }

        private IQueryable<T> _list;

        public int Page;
        public int PageSize;
        public int TotallPage;
        public int TotallItem;
        public IQueryable<T> Items
        {
            get
            {
                if (_list == null) return null;
                return _list;
            }
        }
        public int PageItemCount
        {
            get
            {
                return _list == null ? 0 : _list.Count();
            }
        }
    }
}
