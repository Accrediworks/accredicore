using Accredi.Samples;
using Xunit;

namespace Accredi.EntityFrameworkCore.Applications;

[Collection(AccrediTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AccrediEntityFrameworkCoreTestModule>
{

}
