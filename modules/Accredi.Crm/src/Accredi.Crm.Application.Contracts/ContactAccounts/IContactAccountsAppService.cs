using Accredi.Crm.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.ContactAccounts
{
    public interface IContactAccountsAppService : IApplicationService
    {

        Task<PagedResultDto<ContactAccountDto>> GetListByContactIdAsync(GetContactAccountListInput input);
        Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByContactIdAsync(GetContactAccountListInput input);

        Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListAsync(GetContactAccountsInput input);

        Task<ContactAccountWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ContactAccountDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetAccountLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetContactLevelLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ContactAccountDto> CreateAsync(ContactAccountCreateDto input);

        Task<ContactAccountDto> UpdateAsync(Guid id, ContactAccountUpdateDto input);
    }
}