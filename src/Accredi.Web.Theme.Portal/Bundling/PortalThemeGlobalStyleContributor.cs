using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Accredi.Web.Theme.Portal.Bundling;

public class PortalThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/portal/layout.css");
    }
}
