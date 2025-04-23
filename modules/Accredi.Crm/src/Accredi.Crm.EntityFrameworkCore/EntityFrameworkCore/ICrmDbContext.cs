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
    DbSet<Contact> Contacts { get; set; }
    DbSet<Account> Accounts { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}