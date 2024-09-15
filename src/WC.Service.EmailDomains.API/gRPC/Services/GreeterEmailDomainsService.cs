using Grpc.Core;
using WC.Library.Shared.Exceptions;
using WC.Service.EmailDomains.Domain.Services;

namespace WC.Service.EmailDomains.API.gRPC.Services;

public class GreeterEmailDomainsService : GreeterEmailDomains.GreeterEmailDomainsBase
{
    private readonly IEmailDomainProvider _provider;

    public GreeterEmailDomainsService(
        IEmailDomainProvider provider)
    {
        _provider = provider;
    }

    public override async Task<DoesEmailDomainExistResponse> DoesEmailDomainExist(
        DoesEmailDomainExistRequest request,
        ServerCallContext context)
    {
        try
        {
            var exists =
                await _provider.DoesEmailDomainExist(request.DomainName, cancellationToken: context.CancellationToken);

            return new DoesEmailDomainExistResponse { Exists = exists };
        }
        catch (NotFoundException ex)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"{ex.Message}"));
        }
    }
}
