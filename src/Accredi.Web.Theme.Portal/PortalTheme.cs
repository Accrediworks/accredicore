using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Accredi.Web.Theme.Portal;

[ThemeName(Name)]
public class PortalTheme : ITheme, ITransientDependency
{
    public const string Name = "Basic";

    public virtual string GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
                return "~/Themes/Portal/Layouts/Application.cshtml";
            case StandardLayouts.Account:
                return "~/Themes/Portal/Layouts/Account.cshtml";
            case StandardLayouts.Empty:
                return "~/Themes/Portal/Layouts/Empty.cshtml";
            default:
                return fallbackToDefault ? "~/Themes/Portal/Layouts/Application.cshtml" : null;
        }
    }
}
