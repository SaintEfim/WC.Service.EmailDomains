using Microsoft.Extensions.Logging;
using WC.Service.EmailDomains.Domain.Models;
using WC.Service.EmailDomains.Domain.Services;

namespace WC.Service.EmailDomains.CreateDomain;

public class CreateDomain
{
    private readonly IEmailDomainManager _emailDomainManager;
    private readonly ILogger<CreateDomain> _logger;
    private readonly EmailDomainsOptions _options;

    public CreateDomain(
        ILogger<CreateDomain> logger,
        IEmailDomainManager emailDomainManager,
        EmailDomainsOptions options)
    {
        _emailDomainManager = emailDomainManager;
        _options = options;
        _logger = logger;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var adminEmailDomains = _options.Domains;

        foreach (var emailDomain in adminEmailDomains)
        {
            var registrationPayload = new EmailDomainModel
            {
                DomainName = emailDomain
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
}
