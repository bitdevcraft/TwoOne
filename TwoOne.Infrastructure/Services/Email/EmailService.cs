using TwoOne.Application.Abstraction.Services;
using TwoOne.Domain.Common.Email;

namespace TwoOne.Infrastructure.Services.Email;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(MailRequest request, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
