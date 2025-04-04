using System.ComponentModel.DataAnnotations;

namespace WC.Service.EmailDomains.API.Models.EmailDomain;

public class EmailDomainUpdateDto
{
    [Required]
    public required string DomainName { get; set; }
}
