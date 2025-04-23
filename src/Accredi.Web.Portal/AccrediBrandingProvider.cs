using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Accredi.Localization;

namespace Accredi.Web;

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
