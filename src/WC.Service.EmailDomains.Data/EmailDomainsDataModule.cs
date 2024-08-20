using Autofac;
using WC.Library.Data;

namespace WC.Service.EmailDomains.Data;

public class EmailDomainsDataModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<WcLibraryDataModule>();
    }
}
