using WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainWithDomainNameExist;

namespace WC.Service.EmailDomains.gRPC.Client.Clients;

public interface IGreeterEmailDomainsClient
{
    Task<DoesEmailDomainWithDomainNameExistResponseModel> DoesEmailDomainWithDomainNameExist(
        DoesEmailDomainWithDomainNameExistRequestModel request,
        CancellationToken cancellationToken = default);
}
