using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSmtp
{
    public class SmtpMessageViewModel
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool IsUseCredentials { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }



        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}