using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain;

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

    public async Task<bool> DoesEmailDomainExist(
        string domainName,
        IWcTransaction? transaction = null,
        CancellationToken cancellationToken = default)
    {
        var emailDomains = await Repository.Get(transaction: transaction, cancellationToken: cancellationToken);
        return emailDomains.Any(x => x.DomainName == domainName);
    }
}
