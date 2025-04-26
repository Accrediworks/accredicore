using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.ContactStates
{
    public interface IContactStateRepository : IRepository<ContactState, Guid>
    {
        Task<List<ContactState>> GetListAsync(
            string? filterText = null,
            string? name = null,
            ContactStateType? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            ContactStateType? type = null,
            CancellationToken cancellationToken = default);
    }
}