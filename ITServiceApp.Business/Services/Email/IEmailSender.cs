using ItServiceApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Business.Services.Email
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
     
    }
}
