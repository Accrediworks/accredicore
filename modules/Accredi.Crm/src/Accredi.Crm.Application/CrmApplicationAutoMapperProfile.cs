using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.Countries;
using Accredi.Crm.AccountLocations;
using Accredi.Crm.Contacts;
using System;
using Accredi.Crm.Shared;
using Volo.Abp.AutoMapper;
using Accredi.Crm.Accounts;
using AutoMapper;

namespace Accredi.Crm;

public class CrmApplicationAutoMapperProfile : Profile
{
    public CrmApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Account, AccountDto>();

        CreateMap<AccountLocation, AccountLocationDto>();

        CreateMap<Country, CountryDto>();

        CreateMap<AccountLocationWithNavigationProperties, AccountLocationWithNavigationPropertiesDto>();
        CreateMap<Country, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<Contact, ContactDto>();
        CreateMap<ContactWithNavigationProperties, ContactWithNavigationPropertiesDto>();
        CreateMap<Account, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<ContactEmail, ContactEmailDto>();

        CreateMap<ContactTelephone, ContactTelephoneDto>();

        CreateMap<Contact, ContactDto>().Ignore(x => x.ContactEmails).Ignore(x => x.ContactTelephones);

        CreateMap<ContactState, ContactStateDto>();

        CreateMap<ContactState, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<ContactLevel, ContactLevelDto>();

        CreateMap<ContactLevel, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
    }
}