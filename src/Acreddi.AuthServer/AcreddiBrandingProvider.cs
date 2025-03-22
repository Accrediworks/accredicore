using Microsoft.Extensions.Localization;
using Acreddi.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acreddi;

[Dependency(ReplaceServices = true)]
public class AcreddiBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AcreddiResource> _localizer;

    public AcreddiBrandingProvider(IStringLocalizer<AcreddiResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
