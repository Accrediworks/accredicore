using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.AccountLocations
{
    public interface IAccountLocationRepository : IRepository<AccountLocation, Guid>
    {
        Task<List<AccountLocation>> GetListByAccountIdAsync(
    Guid accountId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default);

        Task<List<AccountLocationWithNavigationProperties>> GetListWithNavigationPropertiesByAccountIdAsync(
            Guid accountId,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<AccountLocationWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<AccountLocationWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? reference = null,
            Guid? countryId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<AccountLocation>> GetListAsync(
                    string? filterText = null,
                    string? reference = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? reference = null,
            Guid? countryId = null,
            CancellationToken cancellationToken = default);
    }
}