using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain;

public class EmailDomainManager
    : DataManagerBase<EmailDomainManager, IEmailDomainRepository, EmailDomainModel, EmailDomainEntity>,
        IEmailDomainManager
{
    public EmailDomainManager(
        IMapper mapper,
        ILogger<EmailDomainManager> logger,
        IEmailDomainRepository repository,
        IEnumerable<IValidator> validators)
        : base(mapper, logger, repository, validators)
    {
    }

    protected override Task<EmailDomainModel> CreateAction(
        EmailDomainModel model,
        IWcTransaction? transaction = null,
        CancellationToken cancellationToken = default)
    {
        model.DomainName = model.DomainName.ToLower();

        return base.CreateAction(model, transaction, cancellationToken);
    }
}
