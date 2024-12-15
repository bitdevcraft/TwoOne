using TwoOne.Domain.Common.Email;

namespace TwoOne.Application.Abstraction.Services;

public interface IEmailService
{
    Task SendEmailAsync(MailRequest request, CancellationToken cancellationToken);
}