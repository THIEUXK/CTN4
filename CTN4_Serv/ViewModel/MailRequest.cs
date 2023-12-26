using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class MailRequest
    {
        public  string? Tendangnhap { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //    public List<IFormFile> Attachments { get; set; }
        public List<string> attachmentPaths { get; set; }
    }
}
