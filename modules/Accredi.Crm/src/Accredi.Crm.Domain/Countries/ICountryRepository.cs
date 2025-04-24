using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.Countries
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {
        Task<List<Country>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? iSO2Code = null,
            string? iSO3Code = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? iSO2Code = null,
            string? iSO3Code = null,
            CancellationToken cancellationToken = default);
    }
}