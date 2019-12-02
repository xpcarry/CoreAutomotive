using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string message, string subject = "");
    }
}
