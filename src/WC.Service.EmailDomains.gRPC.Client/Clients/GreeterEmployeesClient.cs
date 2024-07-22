using Grpc.Net.Client;
using WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainWithDomainNameExist;

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

    public async Task<DoesEmailDomainWithDomainNameExistResponseModel> DoesEmailDomainWithDomainNameExist(
        DoesEmailDomainWithDomainNameExistRequestModel request,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.DoesEmailDomainWithDomainNameExistAsync(
            new DoesEmailDomainWithDomainNameExistRequest { DomainName = request.DomainName },
            cancellationToken: cancellationToken);

        return new DoesEmailDomainWithDomainNameExistResponseModel { Exists = result.Exists };
    }
}
