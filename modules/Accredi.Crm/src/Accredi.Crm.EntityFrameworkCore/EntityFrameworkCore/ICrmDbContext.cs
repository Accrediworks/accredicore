using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.Countries;
using Accredi.Crm.AccountLocations;
using Accredi.Crm.Contacts;
using Accredi.Crm.Accounts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Accredi.Crm.EntityFrameworkCore;

[ConnectionStringName(CrmDbProperties.ConnectionStringName)]
public interface ICrmDbContext : IEfCoreDbContext
{
    DbSet<ContactLevel> ContactLevels { get; set; }
    DbSet<ContactState> ContactStates { get; set; }
    DbSet<ContactTelephone> ContactTelephones { get; set; }
    DbSet<ContactEmail> ContactEmails { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<AccountLocation> AccountLocations { get; set; }
    DbSet<Account> Accounts { get; set; }

    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}