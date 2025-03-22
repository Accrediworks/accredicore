using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Acreddi.Localization;

namespace Acreddi.Web.Public;

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
