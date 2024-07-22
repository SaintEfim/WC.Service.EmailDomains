using Autofac;
using WC.Library.Web.Startup;
using WC.Service.EmailDomains.Domain;
using WC.Service.EmailDomains.gRPC.Server.Services;

namespace WC.Service.EmailDomains.gRPC.Server;

internal sealed class Startup : StartupGrpcBase
{
    public Startup(
        WebApplicationBuilder builder)
        : base(builder)
    {
    }

    public override void ConfigureContainer(
        ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);
        builder.RegisterModule<EmailDomainsDomainModule>();
    }

    public override void Configure(
        WebApplication app)
    {
        base.Configure(app);
        app.MapGrpcService<GreeterEmailDomainsService>();
    }
}
