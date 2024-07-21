using FluentValidation;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.Validators.Create;

public sealed class EmailDomainCreateDbValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainCreateDbValidator(
        IEmailDomainProvider emailDomainProvider)
    {
        RuleFor(x => x)
            .CustomAsync(async (
                emailDomainModel,
                context,
                cancellationToken) =>
            {
                var positions = await emailDomainProvider.Get(cancellationToken: cancellationToken);

                var duplicatePosition = positions.Any(x => x.DomainName == emailDomainModel.DomainName);

                if (duplicatePosition)
                {
                    context.AddFailure(nameof(EmailDomainModel.DomainName),
                        $"Email domain with this {emailDomainModel.DomainName} already exists.");
                }
            });
    }
}
