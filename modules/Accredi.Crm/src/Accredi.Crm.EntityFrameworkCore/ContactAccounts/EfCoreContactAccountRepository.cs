using Accredi.Crm.ContactLevels;
using Accredi.Crm.Accounts;
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

namespace Accredi.Crm.ContactAccounts
{
    public class EfCoreContactAccountRepository : EfCoreRepository<CrmDbContext, ContactAccount, Guid>, IContactAccountRepository
    {
        public EfCoreContactAccountRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ContactAccount>> GetListByContactIdAsync(
           Guid contactId,
           string? sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.ContactId == contactId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactAccountConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.ContactId == contactId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<ContactAccountWithNavigationProperties>> GetListWithNavigationPropertiesByContactIdAsync(
    Guid contactId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = query.Where(x => x.ContactAccount.ContactId == contactId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactAccountConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<ContactAccountWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(contactAccount => new ContactAccountWithNavigationProperties
                {
                    ContactAccount = contactAccount,
                    Account = dbContext.Set<Account>().FirstOrDefault(c => c.Id == contactAccount.AccountId),
                    ContactLevel = dbContext.Set<ContactLevel>().FirstOrDefault(c => c.Id == contactAccount.ContactLevelId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<ContactAccountWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            Guid? accountId = null,
            Guid? contactLevelId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, accountId, contactLevelId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactAccountConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ContactAccountWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from contactAccount in (await GetDbSetAsync())
                   join account in (await GetDbContextAsync()).Set<Account>() on contactAccount.AccountId equals account.Id into accounts
                   from account in accounts.DefaultIfEmpty()
                   join contactLevel in (await GetDbContextAsync()).Set<ContactLevel>() on contactAccount.ContactLevelId equals contactLevel.Id into contactLevels
                   from contactLevel in contactLevels.DefaultIfEmpty()
                   select new ContactAccountWithNavigationProperties
                   {
                       ContactAccount = contactAccount,
                       Account = account,
                       ContactLevel = contactLevel
                   };
        }

        protected virtual IQueryable<ContactAccountWithNavigationProperties> ApplyFilter(
            IQueryable<ContactAccountWithNavigationProperties> query,
            string? filterText,
            Guid? accountId = null,
            Guid? contactLevelId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(accountId != null && accountId != Guid.Empty, e => e.Account != null && e.Account.Id == accountId)
                    .WhereIf(contactLevelId != null && contactLevelId != Guid.Empty, e => e.ContactLevel != null && e.ContactLevel.Id == contactLevelId);
        }

        public virtual async Task<List<ContactAccount>> GetListAsync(
            string? filterText = null,

            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactAccountConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            Guid? accountId = null,
            Guid? contactLevelId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, accountId, contactLevelId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ContactAccount> ApplyFilter(
            IQueryable<ContactAccount> query,
            string? filterText = null
)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
;
        }
    }
}