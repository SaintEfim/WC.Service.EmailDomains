using FluentValidation;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators.Create;

public sealed class EmailDomainCreateDbValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainCreateDbValidator(
        IEmailDomainProvider emailDomainProvider)
    {
        RuleFor(x => x)
            .CustomAsync(async (
                emailDomain,
                context,
                cancellationToken) =>
            {
                var positions = await emailDomainProvider.Get(cancellationToken: cancellationToken);

                var duplicatePosition = positions.Any(x => x.DomainName == emailDomain.DomainName);

                if (duplicatePosition)
                {
                    context.AddFailure(nameof(EmailDomainModel.DomainName),
                        $"Email domain with this {emailDomain.DomainName} already exists.");
                }
            });
    }
}
