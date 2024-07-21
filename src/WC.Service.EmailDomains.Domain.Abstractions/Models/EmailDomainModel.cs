using WC.Library.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Models;

public class EmailDomainModel : ModelBase
{
    public string DomainName { get; set; } = string.Empty;
}
