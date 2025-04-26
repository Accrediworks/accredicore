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

namespace Accredi.Crm.ContactEmails
{
    public class EfCoreContactEmailRepository : EfCoreRepository<CrmDbContext, ContactEmail, Guid>, IContactEmailRepository
    {
        public EfCoreContactEmailRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ContactEmail>> GetListByContactIdAsync(
           Guid contactId,
           string? sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.ContactId == contactId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactEmailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.ContactId == contactId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<ContactEmail>> GetListAsync(
            string? filterText = null,
            string? email = null,
            ContactEmailType? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, email, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactEmailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? email = null,
            ContactEmailType? type = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, email, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ContactEmail> ApplyFilter(
            IQueryable<ContactEmail> query,
            string? filterText = null,
            string? email = null,
            ContactEmailType? type = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Email!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(type.HasValue, e => e.Type == type);
        }
    }
}