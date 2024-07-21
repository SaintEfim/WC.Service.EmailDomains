using Microsoft.Extensions.Logging;
using WC.Service.EmailDomains.Data.PostgreSql.Context;
using WC.Service.EmailDomains.Data.Repositories;

namespace WC.Service.EmailDomains.Data.PostgreSql.Repositories;

public class EmailDomainRepository : EmailDomainRepository<EmailDomainDbContext>
{
    public EmailDomainRepository(
        EmailDomainDbContext context,
        ILogger<EmailDomainRepository> logger)
        : base(context, logger)
    {
    }
}
