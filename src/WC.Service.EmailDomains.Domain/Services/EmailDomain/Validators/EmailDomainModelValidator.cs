using FluentValidation;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators;

public sealed class EmailDomainModelValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainModelValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.DomainName)
            .NotEmpty()
            .Length(3, 50)
            .Matches(@"^(?!.*@)[a-zA-Z0-9-]+\.[a-zA-Z]+$");
    }
}
