using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        private readonly IConfiguration _configuration;

        public AdminMailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            try
            {
                MimeMessage mimeMessage = new();

                string senderName = _configuration["MailSettings:SenderName"];
                string senderEmail = _configuration["MailSettings:SenderEmail"];
                string password = _configuration["MailSettings:Password"];
                string smtpServer = _configuration["MailSettings:SmtpServer"];
                int smtpPort = int.Parse(_configuration["MailSettings:SmtpPort"]);

                mimeMessage.From.Add(new MailboxAddress(senderName, senderEmail));
                mimeMessage.To.Add(new MailboxAddress("User", model.ReceiverName));
                mimeMessage.Subject = model.Subject;

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = model.Body
                };
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                    client.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(senderEmail, password);
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }


                TempData["MailSuccess"] = "Mail başarıyla gönderildi!";
            }
            catch (Exception ex)
            {
                TempData["MailError"] = "Mail gönderilemedi: " + ex.Message;
            }

            return View();
        }


    }
}
