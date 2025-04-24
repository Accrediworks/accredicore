using Accredi.Crm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Accredi.Crm.Permissions;

public class CrmPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CrmPermissions.GroupName, L("Permission:Crm"));

        var accountPermission = myGroup.AddPermission(CrmPermissions.Accounts.Default, L("Permission:Accounts"));
        accountPermission.AddChild(CrmPermissions.Accounts.Create, L("Permission:Create"));
        accountPermission.AddChild(CrmPermissions.Accounts.Edit, L("Permission:Edit"));
        accountPermission.AddChild(CrmPermissions.Accounts.Delete, L("Permission:Delete"));

        var contactPermission = myGroup.AddPermission(CrmPermissions.Contacts.Default, L("Permission:Contacts"));
        contactPermission.AddChild(CrmPermissions.Contacts.Create, L("Permission:Create"));
        contactPermission.AddChild(CrmPermissions.Contacts.Edit, L("Permission:Edit"));
        contactPermission.AddChild(CrmPermissions.Contacts.Delete, L("Permission:Delete"));

        var accountLocationPermission = myGroup.AddPermission(CrmPermissions.AccountLocations.Default, L("Permission:AccountLocations"));
        accountLocationPermission.AddChild(CrmPermissions.AccountLocations.Create, L("Permission:Create"));
        accountLocationPermission.AddChild(CrmPermissions.AccountLocations.Edit, L("Permission:Edit"));
        accountLocationPermission.AddChild(CrmPermissions.AccountLocations.Delete, L("Permission:Delete"));

        var countryPermission = myGroup.AddPermission(CrmPermissions.Countries.Default, L("Permission:Countries"));
        countryPermission.AddChild(CrmPermissions.Countries.Create, L("Permission:Create"));
        countryPermission.AddChild(CrmPermissions.Countries.Edit, L("Permission:Edit"));
        countryPermission.AddChild(CrmPermissions.Countries.Delete, L("Permission:Delete"));

        var contactEmailPermission = myGroup.AddPermission(CrmPermissions.ContactEmails.Default, L("Permission:ContactEmails"));
        contactEmailPermission.AddChild(CrmPermissions.ContactEmails.Create, L("Permission:Create"));
        contactEmailPermission.AddChild(CrmPermissions.ContactEmails.Edit, L("Permission:Edit"));
        contactEmailPermission.AddChild(CrmPermissions.ContactEmails.Delete, L("Permission:Delete"));

        var contactTelephonePermission = myGroup.AddPermission(CrmPermissions.ContactTelephones.Default, L("Permission:ContactTelephones"));
        contactTelephonePermission.AddChild(CrmPermissions.ContactTelephones.Create, L("Permission:Create"));
        contactTelephonePermission.AddChild(CrmPermissions.ContactTelephones.Edit, L("Permission:Edit"));
        contactTelephonePermission.AddChild(CrmPermissions.ContactTelephones.Delete, L("Permission:Delete"));

        var contactStatePermission = myGroup.AddPermission(CrmPermissions.ContactStates.Default, L("Permission:ContactStates"));
        contactStatePermission.AddChild(CrmPermissions.ContactStates.Create, L("Permission:Create"));
        contactStatePermission.AddChild(CrmPermissions.ContactStates.Edit, L("Permission:Edit"));
        contactStatePermission.AddChild(CrmPermissions.ContactStates.Delete, L("Permission:Delete"));

        var contactLevelPermission = myGroup.AddPermission(CrmPermissions.ContactLevels.Default, L("Permission:ContactLevels"));
        contactLevelPermission.AddChild(CrmPermissions.ContactLevels.Create, L("Permission:Create"));
        contactLevelPermission.AddChild(CrmPermissions.ContactLevels.Edit, L("Permission:Edit"));
        contactLevelPermission.AddChild(CrmPermissions.ContactLevels.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CrmResource>(name);
    }
}