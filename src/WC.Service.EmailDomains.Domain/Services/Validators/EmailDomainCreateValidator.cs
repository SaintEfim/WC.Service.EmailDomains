using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.Validators;

public sealed class EmailDomainCreateModelValidator
    : AbstractValidator<EmailDomainModel>,
        IDomainCreateValidator
{
    public EmailDomainCreateModelValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmailDomainModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmailDomainCreateDbValidator>());
    }
}
