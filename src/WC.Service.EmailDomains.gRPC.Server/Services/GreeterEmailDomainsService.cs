using Grpc.Core;
using WC.Service.EmailDomains.Domain.Services;

namespace WC.Service.EmailDomains.gRPC.Server.Services;

public class GreeterEmailDomainsService : GreeterEmailDomains.GreeterEmailDomainsBase
{
    private readonly IEmailDomainProvider _provider;

    public GreeterEmailDomainsService(
        IEmailDomainProvider provider)
    {
        _provider = provider;
    }

    public override async Task<DoesEmailDomainWithDomainNameExistResponse> DoesEmailDomainWithDomainNameExist(
        DoesEmailDomainWithDomainNameExistRequest request,
        ServerCallContext context)
    {
        var exists = await _provider.DoesEmailDomainWithDomainNameExist(request.DomainName, context.CancellationToken);

        return new DoesEmailDomainWithDomainNameExistResponse { Exists = exists };
    }
}
