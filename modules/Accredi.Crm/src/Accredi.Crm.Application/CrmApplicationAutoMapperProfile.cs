using Accredi.Crm.ContactAccounts;
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

        CreateMap<Country, CountryDto>();

        CreateMap<ContactState, ContactStateDto>();

        CreateMap<ContactTelephone, ContactTelephoneDto>();

        CreateMap<ContactWithNavigationProperties, ContactWithNavigationPropertiesDto>();
        CreateMap<ContactState, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<ContactEmail, ContactEmailDto>();

        CreateMap<Contact, ContactDto>().Ignore(x => x.ContactTelephones).Ignore(x => x.ContactEmails);

        CreateMap<ContactLevel, ContactLevelDto>();

        CreateMap<AccountLocation, AccountLocationDto>();
        CreateMap<AccountLocationWithNavigationProperties, AccountLocationWithNavigationPropertiesDto>();
        CreateMap<Country, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<Account, AccountDto>().Ignore(x => x.AccountLocations);

        CreateMap<ContactAccount, ContactAccountDto>();
        CreateMap<ContactAccountWithNavigationProperties, ContactAccountWithNavigationPropertiesDto>();
        CreateMap<Account, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
        CreateMap<ContactLevel, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
    }
}