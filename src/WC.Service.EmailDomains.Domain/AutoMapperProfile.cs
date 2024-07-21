using AutoMapper;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Domain.Models;

namespace WC.Service.EmailDomains.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmailDomainModel, EmailDomainEntity>()
            .ReverseMap();
    }
}
