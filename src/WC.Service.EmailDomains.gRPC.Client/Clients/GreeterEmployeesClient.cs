using Grpc.Net.Client;
using WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainExist;

namespace WC.Service.EmailDomains.gRPC.Client.Clients;

public class GreeterEmailDomainsClient : IGreeterEmailDomainsClient
{
    private readonly GreeterEmailDomains.GreeterEmailDomainsClient _client;

    public GreeterEmailDomainsClient(
        IEmailDomainsClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmailDomains.GreeterEmailDomainsClient(channel);
    }

    public async Task<DoesEmailDomainExistResponseModel> DoesEmailDomainWithDomainNameExist(
        DoesEmailDomainExistRequestModel request,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.DoesEmailDomainExistAsync(
            new DoesEmailDomainExistRequest { DomainName = request.DomainName }, cancellationToken: cancellationToken);

        return new DoesEmailDomainExistResponseModel { Exists = result.Exists };
    }
}
