using FluentValidation;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators.Update;

public sealed class EmailDomainUpdateDbValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainUpdateDbValidator(
        IEmailDomainRepository repository)
    {
        RuleFor(x => x)
            .CustomAsync(async (
                emailDomain,
                context,
                cancellationToken) =>
            {
                var positions = await repository.Get(cancellationToken: cancellationToken);

                var duplicatePosition = positions.Any(x =>
                    x.DomainName.Equals(emailDomain.DomainName, StringComparison.CurrentCultureIgnoreCase));

                if (duplicatePosition)
                {
                    context.AddFailure(nameof(EmailDomainModel.DomainName),
                        $"Email domain with this {emailDomain.DomainName} already exists.");
                }
            });
    }
}
