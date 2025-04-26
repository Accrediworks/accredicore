using Volo.Abp.Reflection;

namespace Accredi.Qualification.Permissions;

public class QualificationPermissions
{
    public const string GroupName = "Qualification";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(QualificationPermissions));
    }
}
