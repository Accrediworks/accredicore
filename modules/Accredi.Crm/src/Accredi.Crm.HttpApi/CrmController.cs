using Accredi.Crm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Accredi.Crm;

public abstract class CrmController : AbpControllerBase
{
    protected CrmController()
    {
        LocalizationResource = typeof(CrmResource);
    }
}
