﻿using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Pluralsight.AspNetDemo
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var client = new SendGridClient(ConfigurationManager.AppSettings["sendgrid:Key"]);
            var from = new EmailAddress("ajanthan2018@outlook.com");
            var to = new EmailAddress(message.Destination);
            var email = MailHelper.CreateSingleEmail(@from, to, message.Subject, message.Body, message.Body);

            var response = await client.SendEmailAsync(email);
        }
    }
}