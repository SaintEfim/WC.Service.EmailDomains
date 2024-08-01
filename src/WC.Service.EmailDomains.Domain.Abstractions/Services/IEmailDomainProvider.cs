using WC.Library.Domain.Services;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services;

public interface IEmailDomainProvider : IDataProvider<EmailDomainModel>
{
    Task<bool> DoesEmailDomainExist(
        string domainName,
        CancellationToken cancellationToken = default);
}
