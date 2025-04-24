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

    public static class AccountLocations
    {
        public const string Default = GroupName + ".AccountLocations";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Countries
    {
        public const string Default = GroupName + ".Countries";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ContactEmails
    {
        public const string Default = GroupName + ".ContactEmails";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ContactTelephones
    {
        public const string Default = GroupName + ".ContactTelephones";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ContactStates
    {
        public const string Default = GroupName + ".ContactStates";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ContactLevels
    {
        public const string Default = GroupName + ".ContactLevels";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}