using Microsoft.Extensions.Logging;
using WC.Service.EmailDomains.Domain.Models;
using WC.Service.EmailDomains.Domain.Services;

namespace WC.Service.EmailDomains.CreateDomain;

public class CreateDomain
{
    private readonly IEmailDomainManager _emailDomainManager;
    private readonly ILogger<CreateDomain> _logger;

    public CreateDomain(
        ILogger<CreateDomain> logger,
        IEmailDomainManager emailDomainManager)
    {
        _emailDomainManager = emailDomainManager;
        _logger = logger;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var registrationPayload = new EmailDomainModel
        {
            DomainName = Environment.GetEnvironmentVariable("EMAIL_DOMAIN") ?? "admin.com"
        };

        try
        {
            await _emailDomainManager.Create(registrationPayload, cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}
