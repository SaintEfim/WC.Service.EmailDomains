using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using WC.Service.EmailDomains.Data.Models;

namespace WC.Service.EmailDomains.Data.Profile;

public class EmailDomainEntityFilterProfile : SieveProcessor
{
    public EmailDomainEntityFilterProfile(
        IOptions<SieveOptions> options)
        : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<EmailDomainEntity>(p => p.Id)
            .CanFilter();

        mapper.Property<EmailDomainEntity>(p => p.DomainName)
            .CanFilter()
            .CanSort();

        return mapper;
    }
}
