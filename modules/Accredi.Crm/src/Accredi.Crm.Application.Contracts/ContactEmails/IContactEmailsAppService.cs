using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Accredi.Crm.ContactEmails
{
    public interface IContactEmailsAppService : IApplicationService
    {

        Task<PagedResultDto<ContactEmailDto>> GetListByContactIdAsync(GetContactEmailListInput input);

        Task<PagedResultDto<ContactEmailDto>> GetListAsync(GetContactEmailsInput input);

        Task<ContactEmailDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ContactEmailDto> CreateAsync(ContactEmailCreateDto input);

        Task<ContactEmailDto> UpdateAsync(Guid id, ContactEmailUpdateDto input);
    }
}