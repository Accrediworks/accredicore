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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CrmResource>(name);
    }
}