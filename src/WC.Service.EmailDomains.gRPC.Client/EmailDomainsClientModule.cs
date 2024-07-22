using Autofac;
using WC.Service.EmailDomains.gRPC.Client.Clients;

namespace WC.Service.EmailDomains.gRPC.Client;

public class EmailDomainsClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<GreeterEmailDomainsClient>()
            .As<IGreeterEmailDomainsClient>()
            .InstancePerLifetimeScope();
    }
}
