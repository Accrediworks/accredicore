using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.ContactLevels
{
    public interface IContactLevelsAppService : IApplicationService
    {

        Task<PagedResultDto<ContactLevelDto>> GetListAsync(GetContactLevelsInput input);

        Task<ContactLevelDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ContactLevelDto> CreateAsync(ContactLevelCreateDto input);

        Task<ContactLevelDto> UpdateAsync(Guid id, ContactLevelUpdateDto input);
    }
}