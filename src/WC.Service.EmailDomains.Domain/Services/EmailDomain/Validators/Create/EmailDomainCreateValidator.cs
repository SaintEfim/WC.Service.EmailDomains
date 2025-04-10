﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators.Create;

public sealed class EmailDomainCreateValidator
    : AbstractValidator<EmailDomainModel>,
        IDomainCreateValidator
{
    public EmailDomainCreateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmailDomainModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmailDomainCreateDbValidator>());
    }
}
