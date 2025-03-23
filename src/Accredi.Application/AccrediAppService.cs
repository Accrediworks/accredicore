using Accredi.Localization;
using Volo.Abp.Application.Services;

namespace Accredi;

/* Inherit your application services from this class.
 */
public abstract class AccrediAppService : ApplicationService
{
    protected AccrediAppService()
    {
        LocalizationResource = typeof(AccrediResource);
    }
}
