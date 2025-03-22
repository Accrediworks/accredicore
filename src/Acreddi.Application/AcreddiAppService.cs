using Acreddi.Localization;
using Volo.Abp.Application.Services;

namespace Acreddi;

/* Inherit your application services from this class.
 */
public abstract class AcreddiAppService : ApplicationService
{
    protected AcreddiAppService()
    {
        LocalizationResource = typeof(AcreddiResource);
    }
}
