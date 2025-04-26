using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.ContactLevels
{
    public interface IContactLevelRepository : IRepository<ContactLevel, Guid>
    {
        Task<List<ContactLevel>> GetListAsync(
            string? filterText = null,
            string? name = null,
            ContactLevelType? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            ContactLevelType? type = null,
            CancellationToken cancellationToken = default);
    }
}