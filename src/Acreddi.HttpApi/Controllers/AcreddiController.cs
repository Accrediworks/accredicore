using Acreddi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acreddi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AcreddiController : AbpControllerBase
{
    protected AcreddiController()
    {
        LocalizationResource = typeof(AcreddiResource);
    }
}
