using AutoMapper;
using WC.Library.Web.Models;
using WC.Service.EmailDomains.API.Models.EmailDomain;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmailDomainModel, EmailDomainDto>();

        CreateMap<EmailDomainCreateDto, EmailDomainModel>();

        CreateMap<EmailDomainModel, CreateActionResultDto>();

        CreateMap<EmailDomainUpdateDto, EmailDomainModel>()
            .ReverseMap();
    }
}
