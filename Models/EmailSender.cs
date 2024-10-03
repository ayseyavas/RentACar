using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{


    public Task SendEmailAsync(string email, string subject, string message)
    {
        // E-posta gönderme işlemleri burada yapılır
        var smtpClient = new SmtpClient("smtp.example.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("your_email@example.com", "your_password"),
            EnableSsl = true,
        };

        smtpClient.SendMailAsync(new MailMessage("your_email@example.com", email, subject, message));

        return Task.CompletedTask;
    }
}
