using Accredi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Accredi.Permissions;

public class AccrediPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AccrediPermissions.GroupName);

        myGroup.AddPermission(AccrediPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AccrediPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var booksPermission = myGroup.AddPermission(AccrediPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AccrediPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AccrediPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AccrediPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AccrediPermissions.MyPermission1, L("Permission:MyPermission1"));

        var accountPermission = myGroup.AddPermission(AccrediPermissions.Accounts.Default, L("Permission:Accounts"));
        accountPermission.AddChild(AccrediPermissions.Accounts.Create, L("Permission:Create"));
        accountPermission.AddChild(AccrediPermissions.Accounts.Edit, L("Permission:Edit"));
        accountPermission.AddChild(AccrediPermissions.Accounts.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AccrediResource>(name);
    }
}