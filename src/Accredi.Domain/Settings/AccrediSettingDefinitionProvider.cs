using Volo.Abp.Settings;

namespace Accredi.Settings;

public class AccrediSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AccrediSettings.MySetting1));
    }
}
