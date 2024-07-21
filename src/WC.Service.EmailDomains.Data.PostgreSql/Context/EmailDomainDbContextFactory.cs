using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.EmailDomains.Data.PostgreSql.Context;

public sealed class EmailDomainDbContextFactory : PostgreSqlDbContextFactoryBase<EmailDomainDbContext>
{
    public EmailDomainDbContextFactory(
        IConfiguration configuration,
        IHostEnvironment environment)
        : base(configuration, environment)
    {
    }

    protected override string ConnectionString => "ServiceDB";
}
