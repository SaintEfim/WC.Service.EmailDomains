using Microsoft.Extensions.Logging;
using Sieve.Services;
using WC.Service.EmailDomains.Data.PostgreSql.Context;
using WC.Service.EmailDomains.Data.Repositories;

namespace WC.Service.EmailDomains.Data.PostgreSql.Repositories;

public class EmailDomainRepository : EmailDomainRepository<EmailDomainDbContext>
{
    public EmailDomainRepository(
        EmailDomainDbContext context,
        ILogger<EmailDomainRepository> logger,
        ISieveProcessor sieveProcessor)
        : base(context, logger, sieveProcessor)
    {
    }
}
