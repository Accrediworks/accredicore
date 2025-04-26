using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.ContactAccounts
{
    public interface IContactAccountRepository : IRepository<ContactAccount, Guid>
    {
        Task<List<ContactAccount>> GetListByContactIdAsync(
    Guid contactId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default);

        Task<List<ContactAccountWithNavigationProperties>> GetListWithNavigationPropertiesByContactIdAsync(
            Guid contactId,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<ContactAccountWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<ContactAccountWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            Guid? accountId = null,
            Guid? contactLevelId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<ContactAccount>> GetListAsync(
                    string? filterText = null,

                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            Guid? accountId = null,
            Guid? contactLevelId = null,
            CancellationToken cancellationToken = default);
    }
}