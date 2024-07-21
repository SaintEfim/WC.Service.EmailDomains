using Autofac;
using Microsoft.EntityFrameworkCore;
using WC.Library.Data.Repository;
using WC.Service.EmailDomains.Data.PostgreSql.Context;

namespace WC.Service.EmailDomains.Data.PostgreSql;

public class EmailDomainsDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmailDomainDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<EmailDomainDbContextFactory>()
                .CreateDbContext())
            .As<EmailDomainDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
