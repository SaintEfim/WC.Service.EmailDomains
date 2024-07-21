using Autofac;
using WC.Service.EmailDomains.Domain;
using StartupBase = WC.Library.Web.Startup.StartupBase;

namespace WC.Service.EmailDomains.API;

internal sealed class Startup : StartupBase
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
}
