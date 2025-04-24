using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.ContactEmails
{
    public interface IContactEmailRepository : IRepository<ContactEmail, Guid>
    {
        Task<List<ContactEmail>> GetListByContactIdAsync(
    Guid contactId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default);

        Task<List<ContactEmail>> GetListAsync(
                    string? filterText = null,
                    string? email = null,
                    ContactEmailType? type = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? email = null,
            ContactEmailType? type = null,
            CancellationToken cancellationToken = default);
    }
}