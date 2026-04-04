namespace TheWatchers.Application.Services;

public record SmtpClientSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public bool UseDefaultCredentials { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
