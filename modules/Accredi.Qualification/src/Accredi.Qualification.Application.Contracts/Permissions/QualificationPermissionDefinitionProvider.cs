using Accredi.Qualification.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Accredi.Qualification.Permissions;

public class QualificationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QualificationPermissions.GroupName, L("Permission:Qualification"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QualificationResource>(name);
    }
}
