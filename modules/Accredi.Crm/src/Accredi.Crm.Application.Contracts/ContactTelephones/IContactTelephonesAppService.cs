using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.ContactTelephones
{
    public interface IContactTelephonesAppService : IApplicationService
    {

        Task<PagedResultDto<ContactTelephoneDto>> GetListByContactIdAsync(GetContactTelephoneListInput input);

        Task<PagedResultDto<ContactTelephoneDto>> GetListAsync(GetContactTelephonesInput input);

        Task<ContactTelephoneDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ContactTelephoneDto> CreateAsync(ContactTelephoneCreateDto input);

        Task<ContactTelephoneDto> UpdateAsync(Guid id, ContactTelephoneUpdateDto input);
    }
}