using Acreddi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acreddi.Permissions;

public class AcreddiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AcreddiPermissions.GroupName);

        myGroup.AddPermission(AcreddiPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AcreddiPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var booksPermission = myGroup.AddPermission(AcreddiPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AcreddiPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AcreddiPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AcreddiPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AcreddiPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AcreddiResource>(name);
    }
}
