using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Accredi.Crm.EntityFrameworkCore;

namespace Accredi.Crm.ContactTelephones
{
    public class EfCoreContactTelephoneRepository : EfCoreRepository<CrmDbContext, ContactTelephone, Guid>, IContactTelephoneRepository
    {
        public EfCoreContactTelephoneRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ContactTelephone>> GetListByContactIdAsync(
           Guid contactId,
           string? sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.ContactId == contactId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactTelephoneConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.ContactId == contactId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<ContactTelephone>> GetListAsync(
            string? filterText = null,
            string? telephone = null,
            ContactTelephoneType? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, telephone, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactTelephoneConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? telephone = null,
            ContactTelephoneType? type = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, telephone, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ContactTelephone> ApplyFilter(
            IQueryable<ContactTelephone> query,
            string? filterText = null,
            string? telephone = null,
            ContactTelephoneType? type = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Telephone!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(telephone), e => e.Telephone.Contains(telephone))
                    .WhereIf(type.HasValue, e => e.Type == type);
        }
    }
}