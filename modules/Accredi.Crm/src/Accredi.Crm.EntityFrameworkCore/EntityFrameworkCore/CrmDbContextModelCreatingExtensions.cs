using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.Countries;
using Accredi.Crm.AccountLocations;
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

        if (builder.IsHostDatabase())
        {
            builder.Entity<Country>(b =>
            {
                b.ToTable(CrmDbProperties.DbTablePrefix + "Countries", CrmDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasColumnName(nameof(Country.Name)).IsRequired();
                b.Property(x => x.ISO2Code).HasColumnName(nameof(Country.ISO2Code)).IsRequired();
                b.Property(x => x.ISO3Code).HasColumnName(nameof(Country.ISO3Code)).IsRequired();
            });

        }
        builder.Entity<Account>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "Accounts", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Account.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(Account.Name)).IsRequired();
                    b.Property(x => x.TaxReference).HasColumnName(nameof(Account.TaxReference));
                    b.HasMany(x => x.AccountLocations).WithOne().HasForeignKey(x => x.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                });
        builder.Entity<AccountLocation>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "AccountLocations", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(AccountLocation.TenantId));
                    b.Property(x => x.Reference).HasColumnName(nameof(AccountLocation.Reference)).IsRequired();
                    b.Property(x => x.Line1).HasColumnName(nameof(AccountLocation.Line1)).IsRequired();
                    b.Property(x => x.Line2).HasColumnName(nameof(AccountLocation.Line2));
                    b.Property(x => x.Line3).HasColumnName(nameof(AccountLocation.Line3));
                    b.Property(x => x.Town).HasColumnName(nameof(AccountLocation.Town)).IsRequired();
                    b.Property(x => x.County).HasColumnName(nameof(AccountLocation.County)).IsRequired();
                    b.Property(x => x.Postcode).HasColumnName(nameof(AccountLocation.Postcode)).IsRequired();
                    b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.NoAction);
                    b.HasOne<Account>().WithMany(x => x.AccountLocations).HasForeignKey(x => x.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                });

        builder.Entity<ContactEmail>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "ContactEmails", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(ContactEmail.TenantId));
                    b.Property(x => x.Email).HasColumnName(nameof(ContactEmail.Email)).IsRequired();
                    b.Property(x => x.Type).HasColumnName(nameof(ContactEmail.Type));
                    b.HasOne<Contact>().WithMany(x => x.ContactEmails).HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                });

        builder.Entity<ContactTelephone>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "ContactTelephones", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(ContactTelephone.TenantId));
                    b.Property(x => x.PhoneNumber).HasColumnName(nameof(ContactTelephone.PhoneNumber)).IsRequired();
                    b.Property(x => x.Type).HasColumnName(nameof(ContactTelephone.Type));
                    b.HasOne<Contact>().WithMany(x => x.ContactTelephones).HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                });

        builder.Entity<ContactState>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "ContactStates", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(ContactState.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(ContactState.Name)).IsRequired();
                    b.Property(x => x.Type).HasColumnName(nameof(ContactState.Type));
                });

        builder.Entity<ContactLevel>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "ContactLevels", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(ContactLevel.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(ContactLevel.Name)).IsRequired();
                    b.Property(x => x.Type).HasColumnName(nameof(ContactLevel.Type));
                });
        builder.Entity<Contact>(b =>
                {
                    b.ToTable(CrmDbProperties.DbTablePrefix + "Contacts", CrmDbProperties.DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Contact.TenantId));
                    b.Property(x => x.Reference).HasColumnName(nameof(Contact.Reference)).IsRequired();
                    b.Property(x => x.Title).HasColumnName(nameof(Contact.Title));
                    b.Property(x => x.FirstName).HasColumnName(nameof(Contact.FirstName)).IsRequired();
                    b.Property(x => x.MiddleName).HasColumnName(nameof(Contact.MiddleName));
                    b.Property(x => x.LastName).HasColumnName(nameof(Contact.LastName)).IsRequired();
                    b.Property(x => x.NationalIdentifier).HasColumnName(nameof(Contact.NationalIdentifier));
                    b.Property(x => x.DateOfBirth).HasColumnName(nameof(Contact.DateOfBirth));
                    b.HasOne<ContactState>().WithMany().IsRequired().HasForeignKey(x => x.ContactStateId).OnDelete(DeleteBehavior.NoAction);
                    b.HasOne<ContactLevel>().WithMany().IsRequired().HasForeignKey(x => x.ContactLevelId).OnDelete(DeleteBehavior.NoAction);
                    b.HasMany(x => x.ContactEmails).WithOne().HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                    b.HasMany(x => x.ContactTelephones).WithOne().HasForeignKey(x => x.ContactId).IsRequired().OnDelete(DeleteBehavior.Cascade);
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