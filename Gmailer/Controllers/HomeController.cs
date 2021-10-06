using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Gmailer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string emailid, string content)
        {
            string senderID = "xxxxxxxx";
            string senderPassword = "xxxxxxx";
            string result = "Email Sent Successfully";

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(emailid);
                mail.From = new MailAddress(senderID);
                mail.Subject = "My Test Email!";
                mail.Body = content;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                result = "problem occurred";
                Response.Write("Exception in sendEmail:" + ex.Message);
            }
            return Json(result);
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