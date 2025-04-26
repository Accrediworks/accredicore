using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.ContactStates
{
    public interface IContactStatesAppService : IApplicationService
    {

        Task<PagedResultDto<ContactStateDto>> GetListAsync(GetContactStatesInput input);

        Task<ContactStateDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ContactStateDto> CreateAsync(ContactStateCreateDto input);

        Task<ContactStateDto> UpdateAsync(Guid id, ContactStateUpdateDto input);
    }
}