using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;

namespace WC.Service.EmailDomains.API.Models;

public class EmailDomainDto : DtoBase
{
    [Required]
    public required string DomainName { get; set; }
}
