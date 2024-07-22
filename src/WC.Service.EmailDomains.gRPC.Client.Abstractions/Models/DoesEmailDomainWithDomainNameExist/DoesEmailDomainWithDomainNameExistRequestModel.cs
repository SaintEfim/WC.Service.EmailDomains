namespace WC.Service.EmailDomains.gRPC.Client.Models.DoesEmailDomainWithDomainNameExist;

public class DoesEmailDomainWithDomainNameExistRequestModel
{
    public required string DomainName { get; set; } = string.Empty;
}
