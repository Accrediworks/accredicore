using Accredi.Crm.Contacts;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Accredi.Crm.Accounts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Accredi.Crm.EntityFrameworkCore;

public static class CrmDbContextModelCreatingExtensions
{
    public static void ConfigureCrm(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(CrmDbProperties.DbTablePrefix + "Questions", CrmDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<Account>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "Accounts", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Account.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(Account.Name)).IsRequired();
                    b.Property(x => x.TaxReference).HasColumnName(nameof(Account.TaxReference));
                });

        builder.Entity<Contact>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "Contacts", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Contact.TenantId));
                    b.Property(x => x.Title).HasColumnName(nameof(Contact.Title));
                    b.Property(x => x.FirstName).HasColumnName(nameof(Contact.FirstName)).IsRequired();
                    b.Property(x => x.MiddleName).HasColumnName(nameof(Contact.MiddleName));
                    b.Property(x => x.LastName).HasColumnName(nameof(Contact.LastName)).IsRequired();
                    b.Property(x => x.NationalIdentifier).HasColumnName(nameof(Contact.NationalIdentifier));
                    b.Property(x => x.DateOfBirth).HasColumnName(nameof(Contact.DateOfBirth));
                    b.HasMany(x => x.Accounts).WithOne().HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                });

        builder.Entity<ContactAccount>(b =>
    {
        b.ToTable(CrmDbProperties.DbTablePrefix + "ContactAccount", CrmDbProperties.DbSchema);
        b.ConfigureByConvention();

        b.HasKey(
            x => new { x.ContactId, x.AccountId }
        );

        b.HasOne<Contact>().WithMany(x => x.Accounts).HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        b.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(
                x => new { x.ContactId, x.AccountId }
        );
    });
    }
}