using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.Accounts;
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

namespace Accredi.Crm.Contacts
{
    public class EfCoreContactRepository : EfCoreRepository<CrmDbContext, Contact, Guid>, IContactRepository
    {
        public EfCoreContactRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<ContactWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id).Include(x => x.Accounts)
                .Select(contact => new ContactWithNavigationProperties
                {
                    Contact = contact,
                    ContactState = dbContext.Set<ContactState>().FirstOrDefault(c => c.Id == contact.ContactStateId),
                    ContactLevel = dbContext.Set<ContactLevel>().FirstOrDefault(c => c.Id == contact.ContactLevelId),
                    Accounts = (from contactAccounts in contact.Accounts
                                join _account in dbContext.Set<Account>() on contactAccounts.AccountId equals _account.Id
                                select _account).ToList()
                }).FirstOrDefault();
        }

        public virtual async Task<List<ContactWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null,
            Guid? contactStateId = null,
            Guid? contactLevelId = null,
            Guid? accountId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, reference, firstName, lastName, nationalIdentifier, dateOfBirthMin, dateOfBirthMax, contactStateId, contactLevelId, accountId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ContactWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from contact in (await GetDbSetAsync())
                   join contactState in (await GetDbContextAsync()).Set<ContactState>() on contact.ContactStateId equals contactState.Id into contactStates
                   from contactState in contactStates.DefaultIfEmpty()
                   join contactLevel in (await GetDbContextAsync()).Set<ContactLevel>() on contact.ContactLevelId equals contactLevel.Id into contactLevels
                   from contactLevel in contactLevels.DefaultIfEmpty()
                   select new ContactWithNavigationProperties
                   {
                       Contact = contact,
                       ContactState = contactState,
                       ContactLevel = contactLevel,
                       Accounts = new List<Account>()
                   };
        }

        protected virtual IQueryable<ContactWithNavigationProperties> ApplyFilter(
            IQueryable<ContactWithNavigationProperties> query,
            string? filterText,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null,
            Guid? contactStateId = null,
            Guid? contactLevelId = null,
            Guid? accountId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Contact.Reference!.Contains(filterText!) || e.Contact.FirstName!.Contains(filterText!) || e.Contact.LastName!.Contains(filterText!) || e.Contact.NationalIdentifier!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(reference), e => e.Contact.Reference.Contains(reference))
                    .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.Contact.FirstName.Contains(firstName))
                    .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.Contact.LastName.Contains(lastName))
                    .WhereIf(!string.IsNullOrWhiteSpace(nationalIdentifier), e => e.Contact.NationalIdentifier.Contains(nationalIdentifier))
                    .WhereIf(dateOfBirthMin.HasValue, e => e.Contact.DateOfBirth >= dateOfBirthMin!.Value)
                    .WhereIf(dateOfBirthMax.HasValue, e => e.Contact.DateOfBirth <= dateOfBirthMax!.Value)
                    .WhereIf(contactStateId != null && contactStateId != Guid.Empty, e => e.ContactState != null && e.ContactState.Id == contactStateId)
                    .WhereIf(contactLevelId != null && contactLevelId != Guid.Empty, e => e.ContactLevel != null && e.ContactLevel.Id == contactLevelId)
                    .WhereIf(accountId != null && accountId != Guid.Empty, e => e.Contact.Accounts.Any(x => x.AccountId == accountId));
        }

        public virtual async Task<List<Contact>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, reference, firstName, lastName, nationalIdentifier, dateOfBirthMin, dateOfBirthMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null,
            Guid? contactStateId = null,
            Guid? contactLevelId = null,
            Guid? accountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, reference, firstName, lastName, nationalIdentifier, dateOfBirthMin, dateOfBirthMax, contactStateId, contactLevelId, accountId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Contact> ApplyFilter(
            IQueryable<Contact> query,
            string? filterText = null,
            string? reference = null,
            string? firstName = null,
            string? lastName = null,
            string? nationalIdentifier = null,
            DateOnly? dateOfBirthMin = null,
            DateOnly? dateOfBirthMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Reference!.Contains(filterText!) || e.FirstName!.Contains(filterText!) || e.LastName!.Contains(filterText!) || e.NationalIdentifier!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(reference), e => e.Reference.Contains(reference))
                    .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName))
                    .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.LastName.Contains(lastName))
                    .WhereIf(!string.IsNullOrWhiteSpace(nationalIdentifier), e => e.NationalIdentifier.Contains(nationalIdentifier))
                    .WhereIf(dateOfBirthMin.HasValue, e => e.DateOfBirth >= dateOfBirthMin!.Value)
                    .WhereIf(dateOfBirthMax.HasValue, e => e.DateOfBirth <= dateOfBirthMax!.Value);
        }
    }
}