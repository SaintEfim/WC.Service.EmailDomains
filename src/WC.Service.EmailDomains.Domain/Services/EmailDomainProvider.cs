using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services;

public class EmailDomainProvider
    : DataProviderBase<EmailDomainProvider, IEmailDomainRepository, EmailDomainModel, EmailDomainEntity>,
        IEmailDomainProvider
{
    public EmailDomainProvider(
        IMapper mapper,
        ILogger<EmailDomainProvider> logger,
        IEmailDomainRepository repository)
        : base(mapper, logger, repository)
    {
    }

    public async Task<bool> DoesEmailDomainWithDomainNameExist(
        string domainName,
        CancellationToken cancellationToken = default)
    {
        var emailDomains = await Repository.Get(cancellationToken: cancellationToken);
        return emailDomains.Any(x => x.DomainName == domainName);
    }
}
