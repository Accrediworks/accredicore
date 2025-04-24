using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.Countries;
using Accredi.Crm.AccountLocations;
using Accredi.Crm.Contacts;
using Accredi.Crm.Accounts;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Accredi.Crm.EntityFrameworkCore;

[ConnectionStringName(CrmDbProperties.ConnectionStringName)]
public class CrmDbContext : AbpDbContext<CrmDbContext>, ICrmDbContext
{
    public DbSet<ContactLevel> ContactLevels { get; set; } = null!;
    public DbSet<ContactState> ContactStates { get; set; } = null!;
    public DbSet<ContactTelephone> ContactTelephones { get; set; } = null!;
    public DbSet<ContactEmail> ContactEmails { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<AccountLocation> AccountLocations { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CrmDbContext(DbContextOptions<CrmDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCrm();
    }
}