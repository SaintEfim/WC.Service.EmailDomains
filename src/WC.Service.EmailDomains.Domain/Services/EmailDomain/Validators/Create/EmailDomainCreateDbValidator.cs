using FluentValidation;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators.Create;

public sealed class EmailDomainCreateDbValidator : AbstractValidator<EmailDomainModel>
{
    public EmailDomainCreateDbValidator(
        IEmailDomainRepository repository)
    {
        RuleFor(x => x)
            .CustomAsync(async (
                emailDomain,
                context,
                cancellationToken) =>
            {
                var positions = await repository.Get(cancellationToken: cancellationToken);

                var duplicatePosition = positions.Any(x => x.DomainName == emailDomain.DomainName);

                if (duplicatePosition)
                {
                    context.AddFailure(nameof(EmailDomainModel.DomainName),
                        $"Email domain with this {emailDomain.DomainName} already exists.");
                }
            });
    }
}
