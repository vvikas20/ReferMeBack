﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IEmailService
    {
        void SendEmail(string emailFrom, string emailTo, string subject, string body);
        void SendAsyncMail(string emailFrom, string emailTo, string subject, string body);
    }
}
