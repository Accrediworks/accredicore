using Accredi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Accredi.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class AccrediPublicPageModel : AbpPageModel
{
    protected AccrediPublicPageModel()
    {
        LocalizationResourceType = typeof(AccrediResource);
    }
}
