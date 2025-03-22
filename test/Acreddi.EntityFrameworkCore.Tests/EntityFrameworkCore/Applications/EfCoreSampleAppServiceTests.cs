using Acreddi.Samples;
using Xunit;

namespace Acreddi.EntityFrameworkCore.Applications;

[Collection(AcreddiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AcreddiEntityFrameworkCoreTestModule>
{

}
