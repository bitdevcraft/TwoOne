namespace TwoOne.Domain.Common.Email;

public class MailRequest
{
    public MailRequest(string subject, string body, string recipient)
    {
        Subject = subject;
        Body = body;
        Recipient = recipient;
    }
    
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Recipient { get; set; }
    public string? Cc { get; set; }
    public string? Bcc { get; set; }
}