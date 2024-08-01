using WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainExist;

namespace WC.Service.EmailDomains.gRPC.Client.Clients;

public interface IGreeterEmailDomainsClient
{
    Task<DoesEmailDomainExistResponseModel> DoesEmailDomainWithDomainNameExist(
        DoesEmailDomainExistRequestModel request,
        CancellationToken cancellationToken = default);
}
