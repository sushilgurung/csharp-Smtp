using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TestSmtp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(SmtpMessageViewModel model)
        {


            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    SmtpClient smtp = new SmtpClient()
                    {
                        Host = model.SmtpServer,
                        Port = model.SmtpPort,
                        EnableSsl = model.EnableSsl
                    };
                    if (model.IsUseCredentials)
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(model.SmtpUserName, model.SmtpPassword);
                    }

                    MailMessage mailMessage = new MailMessage()
                    {
                        From = new MailAddress(model.EmailFrom),
                        Body = model.Body,
                        Subject = model.Subject
                    };
                    mailMessage.To.Add(model.EmailTo);
                    smtp.Send(mailMessage);

                    // Info.  
                    return this.Json(new
                    {
                        EnableSuccess = true,
                        SuccessTitle = "Success",
                        SuccessMsg = "Email Send"
                    });
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
                return this.Json(new
                {
                    EnableError = true,
                    ErrorTitle = "Error",
                    ErrorMsg = ex.Message
                });
            }
            // Info  
            return this.Json(new
            {
                EnableError = true,
                ErrorTitle = "Error",
                ErrorMsg = "Something goes wrong, please try again later"
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}