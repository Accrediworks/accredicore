using Acreddi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acreddi.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class AcreddiPublicPageModel : AbpPageModel
{
    protected AcreddiPublicPageModel()
    {
        LocalizationResourceType = typeof(AcreddiResource);
    }
}
