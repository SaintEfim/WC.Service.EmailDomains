using System.ComponentModel.DataAnnotations;

namespace WC.Service.EmailDomains.API.Models;

public class EmailDomainCreateDto
{
    [Required]
    public required string DomainName { get; set; }
}
