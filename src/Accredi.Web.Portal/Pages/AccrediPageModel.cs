using Accredi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Accredi.Web.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class AccrediPageModel : AbpPageModel
{
    protected AccrediPageModel()
    {
        LocalizationResourceType = typeof(AccrediResource);
    }
}
