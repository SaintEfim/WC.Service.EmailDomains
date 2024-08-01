using WC.Library.Data.Models;

namespace WC.Service.EmailDomains.Data.Models;

public class EmailDomainEntity : EntityBase
{
    public required string DomainName { get; set; }
}
