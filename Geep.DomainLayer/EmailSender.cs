using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.DomainLayer
{
    public class EmailSender
    {
        //private string _apiKey;
        //public EmailSender(string apiKey)
        //{
        //    _apiKey = apiKey;
        //}
        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var client = new SendGridClient(_apiKey);
        //    var from = new EmailAddress($"noreply@owoni.com", "OWONI");
        //    var to = new EmailAddress(email, email);
        //    var plainTextContent = message;
        //    var htmlContent = message;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    try
        //    {
        //        var response = await client.SendEmailAsync(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //public async Task SendEmailAsync(string email, string subject, string message, string fullName = "")
        //{

        //    var client = new SendGridClient(_apiKey);
        //    var from = new EmailAddress($"noreply@owoni.com", "OWONI");
        //    var to = new EmailAddress(email, email);
        //    var plainTextContent = message;
        //    var htmlContent = message;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    try
        //    {
        //        var response = await client.SendEmailAsync(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}
    }
}
