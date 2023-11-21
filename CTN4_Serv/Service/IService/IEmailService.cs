using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IEmailService
    {
        public Task<string> SendEmailAsync(MailRequest mailRequest);
      
    }
}
