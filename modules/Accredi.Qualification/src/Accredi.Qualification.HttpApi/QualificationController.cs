using Accredi.Qualification.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Accredi.Qualification;

public abstract class QualificationController : AbpControllerBase
{
    protected QualificationController()
    {
        LocalizationResource = typeof(QualificationResource);
    }
}
