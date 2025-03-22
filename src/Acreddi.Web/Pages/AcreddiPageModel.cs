using Acreddi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acreddi.Web.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class AcreddiPageModel : AbpPageModel
{
    protected AcreddiPageModel()
    {
        LocalizationResourceType = typeof(AcreddiResource);
    }
}
