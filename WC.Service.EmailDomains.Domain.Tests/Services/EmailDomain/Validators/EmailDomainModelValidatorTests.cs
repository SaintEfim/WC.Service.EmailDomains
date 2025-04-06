using FluentValidation;
using FluentValidation.TestHelper;
using WC.Service.EmailDomains.Domain.Models;
using WC.Service.EmailDomains.Domain.Services.EmailDomain.Validators;

namespace WC.Service.EmailDomains.Domain.Tests.Services.EmailDomain.Validators;

public class EmailDomainModelValidatorTests
{
    private static async Task Check_Main_Data(
        Func<EmailDomainModel> newModelFunc,
        Action<TestValidationResult<EmailDomainModel>> checkResult)
    {
        var validator = new EmailDomainModelValidator();

        var validationContext = new ValidationContext<EmailDomainModel>(newModelFunc());

        var result = await validator.TestValidateAsync(validationContext);

        checkResult(result);
    }

    [Fact]
    public Task EmailDomain_Positive_Model_Validator()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldNotHaveAnyValidationErrors());

        EmailDomainModel NewModelFunc()
        {
            var data = EmailDomainData.EmailDomainModel();
            return data;
        }
    }

    [Fact]
    public Task EmailDomain_Negative_DomainName_Empty()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("NotEmptyValidator")
                .When(x => x.PropertyName == nameof(EmailDomainModel.DomainName))
                .Only());

        EmailDomainModel NewModelFunc()
        {
            var data = EmailDomainData.EmailDomainModel();
            data.DomainName = string.Empty;

            return data;
        }
    }

    [Fact]
    public Task EmailDomain_Negative_DomainName_Short_Name()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("LengthValidator")
                .When(x => x.PropertyName == nameof(EmailDomainModel.DomainName))
                .Only());

        EmailDomainModel NewModelFunc()
        {
            var data = EmailDomainData.EmailDomainModel();
            data.DomainName = new string('a',
                2);

            return data;
        }
    }

    [Fact]
    public Task EmailDomain_Negative_DomainName_Long_Name()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("LengthValidator")
                .When(x => x.PropertyName == nameof(EmailDomainModel.DomainName))
                .Only());

        EmailDomainModel NewModelFunc()
        {
            var data = EmailDomainData.EmailDomainModel();
            data.DomainName = new string('a',
                51);

            return data;
        }
    }

    [Fact]
    public Task EmailDomain_Negative_With_Not_Correct_DomainName()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("RegularExpressionValidator")
                .When(x => x.PropertyName == nameof(EmailDomainModel.DomainName))
                .Only());

        EmailDomainModel NewModelFunc()
        {
            var data = EmailDomainData.EmailDomainModel();
            data.DomainName = "gmail";

            return data;
        }
    }
}
