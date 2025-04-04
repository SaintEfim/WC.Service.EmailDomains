using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Tests.Services.EmailDomain;

public static class EmailDomainData
{
    public static readonly Func<EmailDomainModel> EmailDomainModel =
        () => new EmailDomainModel { DomainName = "gmail.com" };
}
