using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TheWatchers.Application.Services;

namespace TheWatchers.Infrastructure.Services;

public sealed class TheWatchersSmtpClient(ILogger<TheWatchersSmtpClient> logger, IOptions<SmtpClientSettings> options) : ISmtpClient
{
    public SmtpClientSettings ClientSettings
        => options.Value;

    public void Send(MailMessage mailMessage)
    {
        logger?.LogInformation($"Sending email to {string.Join(",", mailMessage.To.Select(item => item.Address))}...");

        try
        {
            using var client = new SmtpClient(ClientSettings.Host, ClientSettings.Port)
            {
                EnableSsl = ClientSettings.EnableSsl,
                UseDefaultCredentials = ClientSettings.UseDefaultCredentials,
                Credentials = new NetworkCredential(ClientSettings.UserName, ClientSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // TODO: uncomment until SMTP is available...
            //client.Send(mailMessage);
        }
        catch (Exception ex)
        {
            logger?.LogCritical(ex, $"Error sending email on TheWatchersSmtpClient");
        }
    }
}
