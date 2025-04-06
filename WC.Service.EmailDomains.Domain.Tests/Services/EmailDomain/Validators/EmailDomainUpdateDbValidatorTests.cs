using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.TestHelper;
using Moq;
using WC.Library.Data.Services;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Data.Repositories;
using WC.Service.EmailDomains.Domain.Models;
using WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators.Update;

namespace WC.Service.EmailDomains.Domain.Tests.Services.EmailDomain.Validators;

public class EmailDomainUpdateDbValidatorTests
{
    private static EmailDomainUpdateDbValidator GetValidator(
        IMock<IEmailDomainRepository> repository)
    {
        var builder = new ContainerBuilder();

        builder.RegisterInstance(repository.Object);

        builder.RegisterType<EmailDomainUpdateDbValidator>();

        builder.Populate([]);

        var container = builder.Build();
        return container.Resolve<EmailDomainUpdateDbValidator>();
    }

    [Fact]
    public async Task EmailDomain_Positive_Update_Record()
    {
        var emailDomain = EmailDomainData.EmailDomainModel();

        var repository = new Mock<IEmailDomainRepository>(MockBehavior.Strict);
        repository.Setup(x => x.Get(default,
                default,
                It.IsAny<IWcTransaction>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<EmailDomainEntity>())
            .Verifiable();

        var validator = GetValidator(repository);

        var result = await validator.TestValidateAsync(emailDomain);

        result.ShouldNotHaveAnyValidationErrors();

        repository.Verify();
    }

    [Fact]
    public async Task EmailDomain_Negative_Update_Record_Has_Duplicate()
    {
        var emailDomain = EmailDomainData.EmailDomainModel();

        emailDomain.DomainName = "Gmail.com";

        var emailDomainEntity = EmailDomainData.EmailDomainEntity();

        var repository = new Mock<IEmailDomainRepository>(MockBehavior.Strict);
        repository.Setup(x => x.Get(default,
                default,
                It.IsAny<IWcTransaction>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<EmailDomainEntity> { emailDomainEntity })
            .Verifiable();

        var validator = GetValidator(repository);

        var result = await validator.TestValidateAsync(emailDomain);

        result.ShouldHaveAnyValidationError()
            .WithErrorMessage($"Email domain with this {emailDomain.DomainName} already exists.")
            .When(x => x.PropertyName == nameof(EmailDomainModel.DomainName));

        repository.Verify();
    }
}
