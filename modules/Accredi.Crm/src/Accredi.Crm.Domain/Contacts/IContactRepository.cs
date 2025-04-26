using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Accredi.Crm.Contacts
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<ContactWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<ContactWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null,
            Guid? contactStateId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Contact>> GetListAsync(
                    string? filterText = null,
                    string? reference = null,
                    string? firstName = null,
                    string? lastName = null,
                    string? nationalIdentifier = null,
                    DateOnly? dateOfBirthMin = null,
                    DateOnly? dateOfBirthMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null,
            Guid? contactStateId = null,
            CancellationToken cancellationToken = default);
    }
}