using Microsoft.Extensions.Localization;
using Accredi.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Accredi;

[Dependency(ReplaceServices = true)]
public class AccrediBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AccrediResource> _localizer;

    public AccrediBrandingProvider(IStringLocalizer<AccrediResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
