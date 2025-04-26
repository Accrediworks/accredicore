using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Accredi.Qualification.EntityFrameworkCore;

[ConnectionStringName(QualificationDbProperties.ConnectionStringName)]
public class QualificationDbContext : AbpDbContext<QualificationDbContext>, IQualificationDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public QualificationDbContext(DbContextOptions<QualificationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureQualification();
    }
}
