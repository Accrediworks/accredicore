using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Accredi.Qualification.EntityFrameworkCore;

[ConnectionStringName(QualificationDbProperties.ConnectionStringName)]
public interface IQualificationDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
