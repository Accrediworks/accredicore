using Volo.Abp.Reflection;

namespace Accredi.Crm.Permissions;

public class CrmPermissions
{
    public const string GroupName = "Crm";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CrmPermissions));
    }

    public static class Accounts
    {
        public const string Default = GroupName + ".Accounts";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Contacts
    {
        public const string Default = GroupName + ".Contacts";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}