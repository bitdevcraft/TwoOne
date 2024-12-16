namespace TwoOne.Infrastructure.Services.Email.Settings;

public class SmtpSetting
{
    public const string SettingsKey = "Mail";

    public string? SenderDisplayName { get; set; }

    public string? SenderEmail { get; set; }

    public string? SmtpPassword { get; set; }

    public string? SmtpServer { get; set; }

    public int SmtpPort { get; set; }
}
