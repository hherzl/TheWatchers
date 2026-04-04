using System.Net.Mail;

namespace TheWatchers.Application.Services;

public interface ISmtpClient
{
    SmtpClientSettings ClientSettings { get; }

    void Send(MailMessage mailMessage);
}
