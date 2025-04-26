using Accredi.Qualification.Localization;
using Volo.Abp.Application.Services;

namespace Accredi.Qualification;

public abstract class QualificationAppService : ApplicationService
{
    protected QualificationAppService()
    {
        LocalizationResource = typeof(QualificationResource);
        ObjectMapperContext = typeof(QualificationApplicationModule);
    }
}
