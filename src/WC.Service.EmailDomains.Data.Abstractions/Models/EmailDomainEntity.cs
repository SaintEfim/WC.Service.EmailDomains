using Sieve.Attributes;
using WC.Library.Data.Models;

namespace WC.Service.EmailDomains.Data.Models;

public class EmailDomainEntity : EntityBase
{
    public string DomainName { get; set; } = string.Empty;
}
