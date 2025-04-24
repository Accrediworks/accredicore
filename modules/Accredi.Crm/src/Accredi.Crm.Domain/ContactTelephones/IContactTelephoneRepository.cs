using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.ContactTelephones
{
    public interface IContactTelephoneRepository : IRepository<ContactTelephone, Guid>
    {
        Task<List<ContactTelephone>> GetListByContactIdAsync(
    Guid contactId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default);

        Task<List<ContactTelephone>> GetListAsync(
                    string? filterText = null,
                    string? phoneNumber = null,
                    ContactTelephoneType? type = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? phoneNumber = null,
            ContactTelephoneType? type = null,
            CancellationToken cancellationToken = default);
    }
}