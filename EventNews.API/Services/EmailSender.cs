using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<BaseResponse> SendMessageAsync(string email, int message)
        {


            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                    Subject = "One time password",
                    Body = message.ToString(),
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
                {
                    Port = Convert.ToInt32(emailSettings["MailPort"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                    EnableSsl = true,
                };

                //smtpClient.UseDefaultCredentials = true;

                await smtpClient.SendMailAsync(mailMessage);

                return new BaseResponse()
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse()
                {
                    IsSuccess = false,
                };
            }

        }
    }
}
