using Volo.Abp.Settings;

namespace Acreddi.Settings;

public class AcreddiSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AcreddiSettings.MySetting1));
    }
}
