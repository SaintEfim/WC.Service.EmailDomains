using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain;

public interface IEmailDomainProvider : IDataProvider<EmailDomainModel>
{
    Task<bool> DoesEmailDomainExist(
        string domainName,
        IWcTransaction? transaction = null,
        CancellationToken cancellationToken = default);
}
