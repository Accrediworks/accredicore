using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

namespace Accredi.Web.Theme.Portal.Themes.Portal.Components.PageAlerts;

public class PageAlertsViewComponent : AbpViewComponent
{
    protected IAlertManager AlertManager { get; }

    public PageAlertsViewComponent(IAlertManager alertManager)
    {
        AlertManager = alertManager;
    }

    public IViewComponentResult Invoke(string name)
    {
        return View("~/Themes/Portal/Components/PageAlerts/Default.cshtml", AlertManager.Alerts);
    }
}
