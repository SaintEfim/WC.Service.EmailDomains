using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.EmailDomains.Data.PostgreSql.Context;

public sealed class EmailDomainDbContextFactory : PostgreSqlDbContextFactoryBase<EmailDomainDbContext>
{
    public EmailDomainDbContextFactory(
        IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override string ConnectionString => "ServiceDB";
}
