using Accredi.Crm.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.AccountLocations
{
    public interface IAccountLocationsAppService : IApplicationService
    {

        Task<PagedResultDto<AccountLocationDto>> GetListByAccountIdAsync(GetAccountLocationListInput input);
        Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByAccountIdAsync(GetAccountLocationListInput input);

        Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListAsync(GetAccountLocationsInput input);

        Task<AccountLocationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<AccountLocationDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<AccountLocationDto> CreateAsync(AccountLocationCreateDto input);

        Task<AccountLocationDto> UpdateAsync(Guid id, AccountLocationUpdateDto input);
    }
}