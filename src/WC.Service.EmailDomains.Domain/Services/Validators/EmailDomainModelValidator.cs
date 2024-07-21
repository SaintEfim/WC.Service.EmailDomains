using FluentValidation;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.Validators;

public sealed class EmailDomainModelValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainModelValidator()
    {
        RuleFor(x => x.DomainName)
            .Matches(".+\\..+");
    }
}
