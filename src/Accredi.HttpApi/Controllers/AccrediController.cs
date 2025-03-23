using Accredi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Accredi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AccrediController : AbpControllerBase
{
    protected AccrediController()
    {
        LocalizationResource = typeof(AccrediResource);
    }
}
