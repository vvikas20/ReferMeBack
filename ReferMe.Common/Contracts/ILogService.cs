using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Common.Contracts
{
    public interface ILogService
    {
        ILog Logger();
    }
}
