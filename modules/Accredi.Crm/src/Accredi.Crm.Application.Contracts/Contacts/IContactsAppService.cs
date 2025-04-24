using Accredi.Crm.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.Contacts
{
    public interface IContactsAppService : IApplicationService
    {

        Task<PagedResultDto<ContactWithNavigationPropertiesDto>> GetListAsync(GetContactsInput input);

        Task<ContactWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ContactDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetContactStateLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetContactLevelLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetAccountLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ContactDto> CreateAsync(ContactCreateDto input);

        Task<ContactDto> UpdateAsync(Guid id, ContactUpdateDto input);
    }
}