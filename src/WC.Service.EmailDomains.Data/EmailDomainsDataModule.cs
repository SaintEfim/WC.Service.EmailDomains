using Autofac;
using Sieve.Services;
using WC.Library.Data;
using WC.Service.EmailDomains.Data.Profile;

namespace WC.Service.EmailDomains.Data;

public class EmailDomainsDataModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<WcLibraryDataModule>();

        builder.RegisterType<EmailDomainEntityFilterProfile>()
            .As<ISieveProcessor>()
            .InstancePerLifetimeScope();
    }
}
