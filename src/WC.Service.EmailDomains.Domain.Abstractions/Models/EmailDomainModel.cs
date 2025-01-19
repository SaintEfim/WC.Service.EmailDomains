using WC.Library.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Models;

public class EmailDomainModel : ModelBase
{
    public required string DomainName { get; set; }
}
