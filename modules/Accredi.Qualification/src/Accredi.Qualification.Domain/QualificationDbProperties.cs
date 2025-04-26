namespace Accredi.Qualification;

public static class QualificationDbProperties
{
    public static string DbTablePrefix { get; set; } = "Qualification";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Qualification";
}
