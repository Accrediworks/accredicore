namespace Accredi.Crm.Accounts
{
    public static class AccountConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Account." : string.Empty);
        }

    }
}