using Accredi.Crm.Countries;
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

namespace Accredi.Crm.AccountLocations
{
    public class EfCoreAccountLocationRepository : EfCoreRepository<CrmDbContext, AccountLocation, Guid>, IAccountLocationRepository
    {
        public EfCoreAccountLocationRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<AccountLocation>> GetListByAccountIdAsync(
           Guid accountId,
           string? sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.AccountId == accountId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AccountLocationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.AccountId == accountId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<AccountLocationWithNavigationProperties>> GetListWithNavigationPropertiesByAccountIdAsync(
    Guid accountId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = query.Where(x => x.AccountLocation.AccountId == accountId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AccountLocationConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<AccountLocationWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(accountLocation => new AccountLocationWithNavigationProperties
                {
                    AccountLocation = accountLocation,
                    Country = dbContext.Set<Country>().FirstOrDefault(c => c.Id == accountLocation.CountryId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<AccountLocationWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? reference = null,
            Guid? countryId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, reference, countryId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AccountLocationConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<AccountLocationWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from accountLocation in (await GetDbSetAsync())
                   join country in (await GetDbContextAsync()).Set<Country>() on accountLocation.CountryId equals country.Id into countries
                   from country in countries.DefaultIfEmpty()
                   select new AccountLocationWithNavigationProperties
                   {
                       AccountLocation = accountLocation,
                       Country = country
                   };
        }

        protected virtual IQueryable<AccountLocationWithNavigationProperties> ApplyFilter(
            IQueryable<AccountLocationWithNavigationProperties> query,
            string? filterText,
            string? reference = null,
            Guid? countryId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.AccountLocation.Reference!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(reference), e => e.AccountLocation.Reference.Contains(reference))
                    .WhereIf(countryId != null && countryId != Guid.Empty, e => e.Country != null && e.Country.Id == countryId);
        }

        public virtual async Task<List<AccountLocation>> GetListAsync(
            string? filterText = null,
            string? reference = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, reference);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AccountLocationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? reference = null,
            Guid? countryId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, reference, countryId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AccountLocation> ApplyFilter(
            IQueryable<AccountLocation> query,
            string? filterText = null,
            string? reference = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Reference!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(reference), e => e.Reference.Contains(reference));
        }
    }
}